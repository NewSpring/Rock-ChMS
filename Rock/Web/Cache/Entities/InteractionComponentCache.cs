﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Concurrent;
using System.Runtime.Serialization;

using Rock.Data;
using Rock.Model;

namespace Rock.Web.Cache
{
    /// <summary>
    /// Information about a interactionComponent that is required by the rendering engine.
    /// This information will be cached by the engine
    /// </summary>
    [Serializable]
    [DataContract]
    public class InteractionComponentCache : ModelCache<InteractionComponentCache, InteractionComponent>
    {
        #region Base Property Overrides

        /// <summary>
        /// The amount of time that this cache's items will live in the cache before expiring
        /// </summary>
        public override TimeSpan? Lifespan
        {
            get
            {
                var minutes = InteractionChannel?.ComponentCacheDuration;
                return ( minutes.HasValue && minutes.Value > 0 ) ?
                    TimeSpan.FromMinutes( minutes.Value ) :
                    base.Lifespan;
            }
        }

        #endregion Base Property Overrides

        #region Static Fields

        private static ConcurrentDictionary<string, int> _interactionComponentLookup = new ConcurrentDictionary<string, int>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        [DataMember]
        public int? EntityId { get; private set; }

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>
        /// The channel identifier.
        /// </value>
        [DataMember]
        [Obsolete( "Use InteractionChannelId instead." )]
        [RockObsolete( "1.11" )]
        public int ChannelId
        {
            get { return InteractionChannelId; }
        }

        /// <summary>
        /// Gets or sets the interaction channel identifier.
        /// </summary>
        /// <value>
        /// The channel identifier.
        /// </value>
        [DataMember]
        public int InteractionChannelId { get; private set; }

        /// <summary>
        /// Gets the interaction channel.
        /// </summary>
        /// <value>
        /// The interaction channel.
        /// </value>
        public InteractionChannelCache InteractionChannel => InteractionChannelCache.Get( InteractionChannelId );

        #endregion

        #region Public Methods

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void SetFromEntity( IEntity entity )
        {
            base.SetFromEntity( entity );

            var interactionComponent = entity as InteractionComponent;
            if ( interactionComponent == null )
                return;

            Name = interactionComponent.Name;
            EntityId = interactionComponent.EntityId;
            InteractionChannelId = interactionComponent.InteractionChannelId;
            var lookupKey = $"{InteractionChannelId}|{EntityId}";

            _interactionComponentLookup.AddOrUpdate( lookupKey, interactionComponent.Id, ( k, v ) => interactionComponent.Id );
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Reads the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        [RockObsolete( "1.8" )]
        [Obsolete( "Use Get Instead", true )]
        public static InteractionComponentCache Read( string guid )
        {
            Guid realGuid = guid.AsGuid();
            if ( realGuid.Equals( Guid.Empty ) )
            {
                return null;
            }

            return Get( realGuid );
        }

        /// <summary>
        /// Gets the component by entity identifier, and creates it if it doesn't exist
        /// </summary>
        /// <param name="interactionChannelId">The interaction channel identifier (so we know what EntityType the entityId is for).</param>
        /// <param name="componentEntityId">The component entity identifier.</param>
        /// <param name="componentName">Name of the component.</param>
        /// <returns></returns>
        public static int GetComponentIdByEntityId( int interactionChannelId, int componentEntityId, string componentName )
        {
            var lookupKey = $"{interactionChannelId}|{componentEntityId}";

            if ( _interactionComponentLookup.TryGetValue( lookupKey, out int componentId ) )
            {
                return componentId;
            }

            using ( var rockContext = new RockContext() )
            {
                int? interactionComponentId = null;
                var interactionComponent = new InteractionComponentService( rockContext ).GetComponentByEntityId( interactionChannelId, componentEntityId, componentName );

                // If a new component was added above we need to save the change
                rockContext.SaveChanges();

                if ( interactionComponent != null )
                {
                    interactionComponentId = Get( interactionComponent ).Id;
                    _interactionComponentLookup.AddOrUpdate( lookupKey, interactionComponent.Id, (k,v) => interactionComponent.Id );
                }

                return interactionComponentId.Value;
            }
        }

        #endregion
    }
}