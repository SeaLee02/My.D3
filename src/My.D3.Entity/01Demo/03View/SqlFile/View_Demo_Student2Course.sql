--创建视图
ALTER VIEW [dbo].[View_Demo_Student2Course]
AS
SELECT CourseGUID,
       Score,
       Student2CourseGUID,
       StudentGUID,
       IsDeleted,
       CreateTime,
       CreateGUID,
       CreatedName,
       ModifiedTime,
       ModifiedGUID,
       ModifiedName
FROM dbo.Demo_Student2Course;