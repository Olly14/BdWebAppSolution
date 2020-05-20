--Insert into [dbo].[Products] Values (NEWID(), 'Strawberry Pie', 'Pie with sliced strawberries laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Apple Pie', 'Pie with sliced apples laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Plum Pie', 'Pie with sliced plum laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Pawpaw Pie', 'Pie with sliced Pawpaw laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Vigan Pie', 'Pie with sliced mixed vegs with with yolk, honey and creme fresh sauce','false','false');



--Insert into dbo.Prices Values (NEWID(), 'XXSmallType', 10.99);
--Insert into dbo.Prices Values (NEWID(), 'XSmallType', 20.99);
--Insert into dbo.Prices Values (NEWID(), 'SmallType', 35.99);
--Insert into dbo.Prices Values (NEWID(), 'XXMediumType', 55.99);
--Insert into dbo.Prices Values (NEWID(), 'XMediumType', 110.99);
--Insert into dbo.Prices Values (NEWID(), 'MediumType', 210.99);
--Insert into dbo.Prices Values (NEWID(), 'XXLargeType', 1500.99);
--Insert into dbo.Prices Values (NEWID(), 'XLargeType', 1000.99);
--Insert into dbo.Prices Values (NEWID(), 'LargeType', 500.99);

--Insert into dbo.Genders Values (NEWID(), 'Male');
--Insert into dbo.Genders Values (NEWID(), 'Female');


--Insert into [Countries] values (NEWID(), 'USA', '239')
--Insert into [Countries] values (NEWID(), 'France', '43')
--Insert into [Countries] values (NEWID(), 'Nigeria', '234')
--Insert into [Countries] values (NEWID(), 'United Kingdom', '44')

Insert into [dbo].[AppUsers] Values (NEWID(), 'aaa09af4-d90c-4fb0-9910-b8d7b04618ed','58D947C6-FE55-4590-A77B-652F9D049E10', 'oresamuel@limdo.com', '07898765432', '1 Love Avenue', 'Colchester', 'Essex', 'SS23 6TY','false','true', 'false', '0', 'A2C1637F-6E7F-46B7-ACD2-18E10E39742D');

select * from dbo.Products 

select * from dbo.Prices

select * from dbo.Genders

select * from dbo.AppUsers



select * from dbo.OrderProducts

select * from dbo.Orders

select * from dbo.OrderItems

select * from dbo.OrderProducts

select * from OrderHistories

select * from OrderItemHistories

select * from dbo.Countries

--delete from dbo.Orders

--delete from dbo.OrderItems

--delete from OrderHistories

--delete from OrderItemHistories

--delete from OrderItemHistories

--delete from AppUsers where AppUserId = 'cdfddf02-7a0d-4a0d-adf8-0b8b42a57e09' 

--exec sp_rename 'OrderHistories', 'OrderHistories'

--update Orders set Status = 'InProcess'