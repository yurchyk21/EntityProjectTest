IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vFilterNameGoups]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[vFilterNameGoups]
AS
SELECT       NEWID() AS Id, dbo.tblFilterNames.Id AS FilterNameId, dbo.tblFilterNames.Name AS FilterName, dbo.tblFilterValue.Id AS FilterValueId, dbo.tblFilterValue.Name AS FilterValue
FROM            dbo.tblFilterNameGroups INNER JOIN
                        dbo.tblFilterNames ON dbo.tblFilterNameGroups.FilterNameId = dbo.tblFilterNames.Id INNER JOIN
                        dbo.tblFilterValue ON dbo.tblFilterNameGroups.FilterValueId = dbo.tblFilterValue.Id'