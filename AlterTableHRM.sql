DBCC CHECKIDENT(Position, RESEED, 0)
insert into Position([Name], [Color]) values 
	('Admin', '#000000'),
	('Accoutant', '#ff822d'),
	('Dev', '#0099FF'),
	('QA', '#FF66FF'),
	('BA', '#009900'),
	('PM', '#FF6600'),
	('DevOps', '#003300'),
	('DataEngineer', '#AAAAAA'),
	('ScrumMaster', '#FF3300')
declare @noneId uniqueidentifier = '00000000-0000-0000-0000-000000000000';
insert into Salary([Id], [Level], [Position], [Money], [Welfare], [CreatorUserId], [CreationTime], [IsDeleted])
	values 
	(newid(), 1, 1, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 2, 1, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 3, 1, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 4, 1, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 5, 1, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 1, 2, 4000000, 2000000, @noneId, getdate(), 0),
	(newid(), 2, 2, 8000000, 4000000, @noneId, getdate(), 0),
	(newid(), 3, 2, 12000000, 6000000, @noneId, getdate(), 0),
	(newid(), 4, 2, 18000000, 9000000, @noneId, getdate(), 0),
	(newid(), 5, 2, 25000000, 12000000, @noneId, getdate(), 0),
	(newid(), 1, 3, 0, 0, @noneId, getdate(), 0),
	(newid(), 2, 3, 8000000, 4000000, @noneId, getdate(), 0),
	(newid(), 3, 3, 12000000, 6000000, @noneId, getdate(), 0),
	(newid(), 4, 3, 20000000, 10000000, @noneId, getdate(), 0),
	(newid(), 5, 3, 40000000, 20000000, @noneId, getdate(), 0),
	(newid(), 1, 4, 0, 0, @noneId, getdate(), 0),
	(newid(), 2, 4, 8000000, 4000000, @noneId, getdate(), 0),
	(newid(), 3, 4, 12000000, 6000000, @noneId, getdate(), 0),
	(newid(), 4, 4, 20000000, 10000000, @noneId, getdate(), 0),
	(newid(), 5, 4, 40000000, 20000000, @noneId, getdate(), 0),
	(newid(), 1, 5, 0, 0, @noneId, getdate(), 0),
	(newid(), 2, 5, 0, 0, @noneId, getdate(), 0),
	(newid(), 3, 5, 21000000, 10000000, @noneId, getdate(), 0),
	(newid(), 4, 5, 50000000, 25000000, @noneId, getdate(), 0),
	(newid(), 5, 5, 99999999, 50000000, @noneId, getdate(), 0),
	(newid(), 1, 6, 0, 0, @noneId, getdate(), 0),
	(newid(), 2, 6, 0, 0, @noneId, getdate(), 0),
	(newid(), 3, 6, 23000000, 11000000, @noneId, getdate(), 0),
	(newid(), 4, 6, 42000000, 20000000, @noneId, getdate(), 0),
	(newid(), 5, 6, 56000000, 32000000, @noneId, getdate(), 0),
	(newid(), 1, 7, 7000000, 3000000, @noneId, getdate(), 0),
	(newid(), 2, 7, 12000000, 6000000, @noneId, getdate(), 0),
	(newid(), 3, 7, 15000000, 7500000, @noneId, getdate(), 0),
	(newid(), 4, 7, 20000000, 10000000, @noneId, getdate(), 0),
	(newid(), 5, 7, 30000000, 15000000, @noneId, getdate(), 0),
	(newid(), 1, 8, 23000000, 10000000, @noneId, getdate(), 0),
	(newid(), 2, 8, 40000000, 20000000, @noneId, getdate(), 0),
	(newid(), 3, 8, 60000000, 30000000, @noneId, getdate(), 0),
	(newid(), 4, 8, 90000000, 40000000, @noneId, getdate(), 0),
	(newid(), 5, 8, 99999999, 50000000, @noneId, getdate(), 0)
insert into Employee([Id], [UserCode], [FullName], [Sex], [Email], [Password], [Phone], [DoB], [Level], [Position], [StartingDate], [Bank], [BankAccount], [TaxCode], [InsuranceStatus], [Identify], [PlaceOfOrigin], [PlaceOfResidence], [DateOfIssue], [IssuedBy], [Status], [CreatorUserId], [CreationTime], [IsDeleted])
	values (newid(), '0000000000', 'Admin', 1, 'admin@gmail.com', '123456', '0123456789', '2001-01-01 00:00:00.0000000', 3, 0, '2001-01-01 00:00:00.0000000', 'VCB', '23112001', '9876543210', '0123698745', '001122334455', 'High Noise', 'Hoang Mike', '2001-01-01T00:00:00.000Z', 'It''s me', 3, '00000000-0000-0000-0000-000000000000', getdate(), 0)

--insert timekeeping
declare @i int = 1;
declare @Date datetime = cast('2023-07-05' as datetime);
declare @totalUser int = (select count(*) from Employee);
while @i <= @totalUser
begin
	declare @UserId uniqueidentifier = (select [Id] from (select row_number() over(order by [FullName] asc) as row, * from Employee where [Status] = 3 and [LeaveDate] is null) c where row = @i);
	declare @j int = 0;
	while @j < 30
		begin
			insert into TimeKeeping ([Id], [EmployeeId],[CreationTime],[CreatorUserId],[Checkin],[Checkout],[Date],[IsDeleted],[Punish],[PhotoCheckin],[PhotoCheckout])
			values (newid(),@UserId,DATEADD(DAY,@j,@Date),'00000000-0000-0000-0000-000000000000',cast('0001-01-01' as datetime2),cast('0001-01-01' as datetime2), DATEADD(DAY,@j,@Date), 0, 0, null, null)
			set @j = @j + 1;
		end
set @i = @i + 1;
end