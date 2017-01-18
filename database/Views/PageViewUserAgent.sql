IF OBJECT_ID(N'[dbo].[vPageViewUserAgent]', 'V') IS NOT NULL
    DROP VIEW vPageViewUserAgent
GO

CREATE VIEW vPageViewUserAgent
AS
SELECT dt.[Id]
      ,dt.DeviceTypeData [UserAgent]
      ,dt.[ClientType]
      ,dt.[OperatingSystem]
      ,dt.[Application] [Browser]
      ,dt.[Guid]
      ,dt.[ForeignId]
      ,dt.[ForeignGuid]
      ,dt.[ForeignKey]
  FROM [InteractionDeviceType] dt