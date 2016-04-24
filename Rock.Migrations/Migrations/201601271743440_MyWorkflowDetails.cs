﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    ///
    /// </summary>
    public partial class MyWorkflowDetails : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            RockMigrationHelper.AddPage( "F3FA9EBE-A540-4106-90E5-2DFB2D72BBF0", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Workflow Detail", "", "E780010F-A725-439D-B76D-9BB01CDE8D1C", "" ); // Site:Rock RMS
            RockMigrationHelper.AddPage( "F3FA9EBE-A540-4106-90E5-2DFB2D72BBF0", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Workflow Entry", "", "50F2F7A3-513F-4048-BE3E-9C5D72DB3B74", "" ); // Site:Rock RMS

            Sql( @"
        UPDATE [Page] SET [BreadCrumbDisplayName] = 0 
        WHERE [GUID] = '50F2F7A3-513F-4048-BE3E-9C5D72DB3B74'
" );

            RockMigrationHelper.AddPageRoute( "E780010F-A725-439D-B76D-9BB01CDE8D1C", "MyWorkflow/{WorkflowId}", "0466956D-0FC9-4C5D-A62A-46C0D91A6DC6" );// for Page:Workflow Detail
            RockMigrationHelper.AddPageRoute( "50F2F7A3-513F-4048-BE3E-9C5D72DB3B74", "MyWorkflowEntry/{WorkflowTypeId}/{WorkflowId}", "F48F6349-4C31-4973-9760-A226A71EC938" );// for Page:Workflow Entry
            RockMigrationHelper.AddPageRoute( "50F2F7A3-513F-4048-BE3E-9C5D72DB3B74", "MyWorkflowEntry/{WorkflowTypeId}", "09AEF994-0FD4-4B0A-9219-97DDD852D300" );// for Page:Workflow Entry

            // Add Block to Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlock( "E780010F-A725-439D-B76D-9BB01CDE8D1C", "", "4A9D62CE-5822-490F-B9EE-6D80037B4F5F", "Workflow Detail", "Main", "", "", 0, "C9AF334C-C331-4520-93FF-7E7BEC557C58" );
            // Add Block to Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlock( "E780010F-A725-439D-B76D-9BB01CDE8D1C", "", "2E9F32D4-B4FC-4A5F-9BE1-B2E3EA624DD3", "Notes", "Main", "", "", 1, "2FC36D2F-16BB-4740-B29F-98A6785CA907" );
            // Add Block to Page: Workflow Entry, Site: Rock RMS
            RockMigrationHelper.AddBlock( "50F2F7A3-513F-4048-BE3E-9C5D72DB3B74", "", "A8BD05C8-6F89-4628-845B-059E686F089A", "Workflow Entry", "Main", "", "", 0, "335A520F-E482-4530-AC32-B7F732D63F4A" );
            // update block order for pages with new blocks if the page,zone has multiple blocks
            
            // Attrib Value for Block:Notes, Attribute:Entity Type Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "F1BCF615-FBCA-4BC2-A912-C35C0DC04174", @"3540e9a7-fe30-43a9-8b0a-a372b63dfc93" );
            // Attrib Value for Block:Notes, Attribute:Show Private Checkbox Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "D68EE1F5-D29F-404B-945D-AD0BE76594C3", @"False" );
            // Attrib Value for Block:Notes, Attribute:Show Security Button Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "00B6EBFF-786D-453E-8746-119D0B45CB3E", @"True" );
            // Attrib Value for Block:Notes, Attribute:Show Alert Checkbox Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "20243A98-4802-48E2-AF61-83956056AC65", @"True" );
            // Attrib Value for Block:Notes, Attribute:Heading Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "3CB0A7DF-996B-4D6C-B3B6-9BBCC40BDC69", @"Notes" );
            // Attrib Value for Block:Notes, Attribute:Heading Icon CSS Class Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "B69937BE-000A-4B94-852F-16DE92344392", @"fa fa-comment" );
            // Attrib Value for Block:Notes, Attribute:Note Term Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "FD0727DC-92F4-4765-82CB-3A08B7D864F8", @"Note" );
            // Attrib Value for Block:Notes, Attribute:Display Type Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "5232BFAE-4DC8-4270-B38F-D29E1B00AB5E", @"Full" );
            // Attrib Value for Block:Notes, Attribute:Use Person Icon Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "C05757C0-E83E-4170-8CBF-C4E1ABEC36E1", @"False" );
            // Attrib Value for Block:Notes, Attribute:Allow Anonymous Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "EB9CBD02-2B0F-4BA3-9112-BC73D54159E7", @"False" );
            // Attrib Value for Block:Notes, Attribute:Add Always Visible Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "8E0BDD15-6B92-4BB0-9138-E9382B60F3A9", @"False" );
            // Attrib Value for Block:Notes, Attribute:Display Order Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "C9FC2C09-1BF5-4711-8F97-0B96633C46B1", @"Descending" );
            // Attrib Value for Block:Notes, Attribute:Allow Backdated Notes Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.AddBlockAttributeValue( "2FC36D2F-16BB-4740-B29F-98A6785CA907", "6184511D-CC68-4FF2-90CB-3AD0AFD59D61", @"False" );

            // Add/Update PageContext for Page:Workflow Detail, Entity: Rock.Model.Workflow, Parameter: workflowid
            RockMigrationHelper.UpdatePageContext( "E780010F-A725-439D-B76D-9BB01CDE8D1C", "Rock.Model.Workflow", "workflowid", "29C6200C-8EA5-48C2-9ADE-DFBBC80A3F76" );

            // Update the 
            RockMigrationHelper.AddBlockAttributeValue( "358A942A-54A8-4BFA-BEC8-ECBF05CA17E2", "F061EC60-2D56-4D77-B6C9-210B9E34115B", @"50f2f7a3-513f-4048-be3e-9c5d72db3b74,09aef994-0fd4-4b0a-9219-97ddd852d300" ); // Entry Page
            RockMigrationHelper.AddBlockAttributeValue( "358A942A-54A8-4BFA-BEC8-ECBF05CA17E2", "246DFB54-78CF-4A51-A68F-B52EBE3C7C74", @"e780010f-a725-439d-b76d-9bb01cde8d1c,0466956d-0fc9-4c5d-a62a-46c0d91a6dc6" ); // Detail Page

        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {

            // Remove Block: Workflow Entry, from Page: Workflow Entry, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "335A520F-E482-4530-AC32-B7F732D63F4A" );
            // Remove Block: Notes, from Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "2FC36D2F-16BB-4740-B29F-98A6785CA907" );
            // Remove Block: Workflow Detail, from Page: Workflow Detail, Site: Rock RMS
            RockMigrationHelper.DeleteBlock( "C9AF334C-C331-4520-93FF-7E7BEC557C58" );

            RockMigrationHelper.DeletePage( "50F2F7A3-513F-4048-BE3E-9C5D72DB3B74" ); //  Page: Workflow Entry, Layout: Full Width, Site: Rock RMS

            RockMigrationHelper.DeletePage( "E780010F-A725-439D-B76D-9BB01CDE8D1C" ); //  Page: Workflow Detail, Layout: Full Width, Site: Rock RMS

            // Delete PageContext for Page:Workflow Detail, Entity: Rock.Model.Workflow, Parameter: workflowid
            RockMigrationHelper.DeletePageContext( "29C6200C-8EA5-48C2-9ADE-DFBBC80A3F76" );

        }
    }
}
