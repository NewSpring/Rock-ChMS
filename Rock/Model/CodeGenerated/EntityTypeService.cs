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
    /// EntityType Service class
    /// </summary>
    public partial class EntityTypeService : Service<EntityType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityTypeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public EntityTypeService(RockContext context) : base(context)
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
        public bool CanDelete( EntityType item, out string errorMessage )
        {
            errorMessage = string.Empty;
 
            if ( new Service<Attribute>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Attribute.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Audit>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Audit.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Auth>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Auth.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<BinaryFileType>( Context ).Queryable().Any( a => a.StorageEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, BinaryFileType.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Category>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Category.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Communication>( Context ).Queryable().Any( a => a.MediumEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Communication.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<CommunicationTemplate>( Context ).Queryable().Any( a => a.MediumEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, CommunicationTemplate.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<DataView>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, DataView.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<DataView>( Context ).Queryable().Any( a => a.TransformEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, DataView.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<DataViewFilter>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, DataViewFilter.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<EntitySet>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, EntitySet.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialGateway>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FinancialGateway.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialScheduledTransactionDetail>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FinancialScheduledTransactionDetail.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialTransactionDetail>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FinancialTransactionDetail.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FollowingEventType>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FollowingEventType.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FollowingEventType>( Context ).Queryable().Any( a => a.FollowedEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FollowingEventType.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FollowingSuggestionType>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, FollowingSuggestionType.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<History>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, History.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<History>( Context ).Queryable().Any( a => a.RelatedEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, History.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<InteractionChannel>( Context ).Queryable().Any( a => a.ComponentEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, InteractionChannel.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<InteractionChannel>( Context ).Queryable().Any( a => a.InteractionEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, InteractionChannel.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<MergeTemplate>( Context ).Queryable().Any( a => a.MergeTemplateTypeEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, MergeTemplate.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<MetricPartition>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, MetricPartition.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<NoteType>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, NoteType.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<PersonBadge>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, PersonBadge.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Report>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Report.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<SignatureDocumentTemplate>( Context ).Queryable().Any( a => a.ProviderEntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, SignatureDocumentTemplate.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Tag>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, Tag.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<UserLogin>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, UserLogin.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<WorkflowTrigger>( Context ).Queryable().Any( a => a.EntityTypeId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", EntityType.FriendlyTypeName, WorkflowTrigger.FriendlyTypeName );
                return false;
            }  
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class EntityTypeExtensionMethods
    {
        /// <summary>
        /// Clones this EntityType object to a new EntityType object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static EntityType Clone( this EntityType source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as EntityType;
            }
            else
            {
                var target = new EntityType();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another EntityType object to this EntityType object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this EntityType target, EntityType source )
        {
            target.Id = source.Id;
            target.AssemblyName = source.AssemblyName;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.FriendlyName = source.FriendlyName;
            target.IsCommon = source.IsCommon;
            target.IsEntity = source.IsEntity;
            target.IsIndexingEnabled = source.IsIndexingEnabled;
            target.IsSecured = source.IsSecured;
            target.MultiValueFieldTypeId = source.MultiValueFieldTypeId;
            target.Name = source.Name;
            target.SingleValueFieldTypeId = source.SingleValueFieldTypeId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
