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
namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// 
    /// </summary>
    [MigrationNumber( 11, "1.6.0" )]
    public class FixNameProfileChangeRequest : Migration
    {
        /// <summary>
        /// The commands to run to migrate plugin to the specific version
        /// </summary>
        public override void Up()
        {
//  Moved to core migration: 201612121647292_HotFixesFrom6_1
//            Sql( @"
//    UPDATE [Page]
//    SET 
//	    [PageTitle] = 'Request Profile Change'
//	    ,[BrowserTitle] = 'Request Profile Change'
//	    ,[InternalName] = 'Request Profile Change'
//    WHERE
//	    [Guid] = 'E1F9DE5A-CF99-4AF5-BEE6-EFC04F6DE57A'
//	    AND [PageTitle] = 'Workflow Entry'
//	    AND [BrowserTitle] = 'Workflow Entry'
//	    AND [InternalName] = 'Workflow Entry'
//" );
        }

        /// <summary>
        /// The commands to undo a migration from a specific version
        /// </summary>
        public override void Down()
        {
        }
    }
}
