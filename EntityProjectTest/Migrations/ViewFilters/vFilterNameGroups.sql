IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vFilterNameGoups]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[vFilterNameGoups]
AS
SELECT        NEWID() AS Id, fn.Id AS FilterNameId, fn.Name AS FilterName, fv.Id AS FilterValueId, 
                         fv.Name AS FilterValue
from tblFilterNames FN
left join tblFilterNameGroups fng on fn.Id = fng.FilternameId
left join tblFilterValue fv on fv.Id = fng.FilterValueId'