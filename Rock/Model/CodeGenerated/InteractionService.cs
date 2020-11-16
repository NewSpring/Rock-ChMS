//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
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
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Interaction Service class
    /// </summary>
    public partial class InteractionService : Service<Interaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public InteractionService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Interaction item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class InteractionExtensionMethods
    {
        /// <summary>
        /// Clones this Interaction object to a new Interaction object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Interaction Clone( this Interaction source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Interaction;
            }
            else
            {
                var target = new Interaction();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another Interaction object to this Interaction object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Interaction target, Interaction source )
        {
            target.Id = source.Id;
            target.Campaign = source.Campaign;
            target.ChannelCustom1 = source.ChannelCustom1;
            target.ChannelCustom2 = source.ChannelCustom2;
            target.ChannelCustomIndexed1 = source.ChannelCustomIndexed1;
            target.Content = source.Content;
            target.EntityId = source.EntityId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.InteractionComponentId = source.InteractionComponentId;
            target.InteractionData = source.InteractionData;
            target.InteractionDateTime = source.InteractionDateTime;
            target.InteractionEndDateTime = source.InteractionEndDateTime;
            target.InteractionLength = source.InteractionLength;
            target.InteractionSessionId = source.InteractionSessionId;
            target.InteractionSummary = source.InteractionSummary;
            target.InteractionTimeToServe = source.InteractionTimeToServe;
            target.Medium = source.Medium;
            target.Operation = source.Operation;
            target.PersonalDeviceId = source.PersonalDeviceId;
            target.PersonAliasId = source.PersonAliasId;
            target.RelatedEntityId = source.RelatedEntityId;
            target.RelatedEntityTypeId = source.RelatedEntityTypeId;
            target.Source = source.Source;
            target.Term = source.Term;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
