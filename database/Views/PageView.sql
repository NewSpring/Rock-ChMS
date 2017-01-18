IF OBJECT_ID(N'[dbo].[vPageView]', 'V') IS NOT NULL
    DROP VIEW vPageView
GO

CREATE VIEW vPageView
AS
SELECT i.[Id]
    ,icp.EntityId [PageId]
    ,ich.ChannelEntityId [SiteId]
    ,i.[PersonAliasId]
    ,i.InteractionDateTime [DateTimeViewed]
    ,i.[Guid]
    ,i.InteractionData [Url]
    ,icp.Name [PageTitle]
    ,i.[ForeignKey]
    ,i.[ForeignGuid]
    ,i.[ForeignId]
    ,iss.Id [PageViewSessionId]
FROM [Interaction] i
join InteractionComponent icp on i.InteractionComponentId = icp.Id
join InteractionChannel ich on icp.ChannelId = ich.Id
join InteractionSession iss on i.InteractionSessionId = iss.Id 

