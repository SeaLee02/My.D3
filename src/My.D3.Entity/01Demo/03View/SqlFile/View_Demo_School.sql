--创建视图
ALTER VIEW [dbo].[View_Demo_School]
AS
SELECT SchoolGUID,
       SchoolCode,
       SchoolName,
       ParentSchoolGUID,
       IsDeleted,
       CreateTime,
       CreateGUID,
       CreatedName,
       ModifiedTime,
       ModifiedGUID,
       ModifiedName
FROM dbo.Demo_School;