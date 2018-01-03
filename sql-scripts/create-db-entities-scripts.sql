USE [WorkloudChallenge]
GO

/****** Object:  Table [dbo].[asd]    Script Date: 1/2/2018 12:34:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Employee] ******/

/* Create Employee table */
CREATE TABLE [dbo].Employee(
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL
)
GO

/* Create 6 columns on the Employee table */

ALTER TABLE [dbo].Employee
  ADD [FirstName] [nvarchar](50) NOT NULL,
      [LastName] [nvarchar](50) NOT NULL,
      [HireDate] [date] NOT NULL,
      [PhoneNumber] [varchar](10) NULL,
      [Salary] [decimal](9, 2) NULL,
      [Bonus] [decimal](9, 2) NULL;

GO

/* Create primary key */

ALTER TABLE    Employee   
ADD CONSTRAINT PK_Employee_EmployeeId PRIMARY KEY CLUSTERED (EmployeeId);  
GO  

/* Insert initial data */
INSERT INTO Employee ([FirstName], [LastName], [HireDate], [PhoneNumber], [Salary], [Bonus])
VALUES ('Dimitris', 'Matrakidis', GetUtcDate(), '2105874', 20000, 1000);

INSERT INTO Employee ([FirstName], [LastName], [HireDate], [PhoneNumber], [Salary], [Bonus])
VALUES ('Maria', 'Apostolidou', GetUtcDate(), '2105374', 20000, 1000);
GO

INSERT INTO Employee ([FirstName], [LastName], [HireDate], [PhoneNumber], [Salary], [Bonus])
VALUES ('Nick', 'Panou', GetUtcDate(), '2105374', 20000, 1000);
GO

INSERT INTO Employee ([FirstName], [LastName], [HireDate], [PhoneNumber], [Salary], [Bonus])
VALUES ('Jim', 'Nelson', GetUtcDate(), '2105374', 50000, 1000);
GO

/****** Object:  Table [dbo].[EmployeeSkills] ******/

CREATE TABLE [dbo].[EmployeeSkill](
	[EmployeeSkillId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	Skill NVARCHAR(50) NOT NULL
    CONSTRAINT [PK_EmployeeSkill] PRIMARY KEY CLUSTERED 
    (
  	 [EmployeeSkillId] ASC
    )
)
GO

ALTER TABLE [dbo].[EmployeeSkill]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkill_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[EmployeeSkill] CHECK CONSTRAINT [FK_EmployeeSkill_Employee]
GO