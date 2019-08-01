--创建视图
ALTER VIEW [dbo].[View_Demo_Course]
AS
SELECT CourseGUID,
       CourseName,
       IsDeleted,
       CreateTime,
       CreateGUID,
       CreatedName,
       ModifiedTime,
       ModifiedGUID,
       ModifiedName
FROM dbo.Demo_Course;