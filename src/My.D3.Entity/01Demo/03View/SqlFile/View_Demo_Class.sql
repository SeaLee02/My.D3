  --创建视图
 ALTER VIEW [dbo].[View_Demo_Class]
 AS 
 SELECT ClassGUID,
        ClassName,
        SchoolGUID,
        IsDeleted,
        CreateTime,
        CreateGUID,
        CreatedName,
        ModifiedTime,
        ModifiedGUID,
        ModifiedName 
FROM dbo.Demo_Class