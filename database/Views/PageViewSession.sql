IF OBJECT_ID(N'[dbo].[vPageViewSession]', 'V') IS NOT NULL
    DROP VIEW vPageViewSession
GO

CREATE VIEW vPageViewSession
AS
SELECT iss.[Id]
    ,iss.DeviceTypeId [PageViewUserAgentId]
    ,iss.[Guid] [SessionId]
    ,iss.[IpAddress]
    ,iss.[Guid]
    ,iss.[ForeignId]
    ,iss.[ForeignGuid]
    ,iss.[ForeignKey]
FROM [InteractionSession] iss
