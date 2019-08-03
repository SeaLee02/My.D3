IF OBJECT_ID ( 'usp_Demo_GetDemoStudent', 'P' ) IS NOT NULL 
    DROP PROCEDURE usp_Demo_GetDemoStudent
GO

-- =============================================
-- Author:		<sealee>
-- Create date: <2018-09-03>
-- Description:	<获取学生根据名称>
-- Example:  exec usp_Demo_GetDemoStudent ''
-- =============================================
CREATE PROCEDURE [dbo].[usp_Demo_GetDemoStudent]
(
	@StuName VARCHAR(40), -- 学生名称
	@OutCount INT OUT --输出总条数
)
AS

BEGIN
    --1 根据学生名称获取数据
    SELECT StudentGUID ,
           StuName ,
           Age ,
           Birthday ,
           Height ,
           IsVIP ,
           ClassGUID 
		   FROM dbo.Demo_Student
	WHERE StuName=@StuName

	--1.1 获取学生总数
	SELECT @OutCount=COUNT(1)
	FROM dbo.Demo_Student

	SELECT * FROM Demo_Student

END


GO