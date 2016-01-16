/*$$$$$$$$$$$$$创建文件夹$$$$$$$$$$$$$$$$$$*/
USE master
GO

EXEC xp_cmdshell 'mkdir d:\bank', NO_OUTPUT   

/*$$$$$$$$$$$$$建库$$$$$$$$$$$$$$$$$$$$$$$$*/
--检验数据库是否存在，如果为真，删除此数据库--
IF exists(SELECT * FROM sysdatabases WHERE name='bankDB')
  DROP DATABASE bankDB
GO
--创建建库bankDB
CREATE DATABASE bankDB
 ON
 (
  NAME='bankDB_data',
  FILENAME='d:\bank\bankDB_data.mdf',
  SIZE=1mb,
  FILEGROWTH=15%
 )
 LOG ON
 (
  NAME= 'bankDB_log',
  FILENAME='d:\bank\bankDB_log.ldf',
  SIZE=1mb,
  FILEGROWTH=15%
 )

GO
/*$$$$$$$$$$$$$建表$$$$$$$$$$$$$$$$$$$$$$$$*/

USE bankDB
GO

CREATE TABLE userInfo  --用户信息表
(
  customerID INT IDENTITY(1,1),
  customerName CHAR(8) NOT NULL,
  PID CHAR(18) NOT NULL,
  telephone CHAR(13) NOT NULL,
  address VARCHAR(50)
)
GO

CREATE TABLE cardInfo  --银行卡信息表
(
  cardID  CHAR(19) NOT NULL,
  curType  CHAR(5) NOT NULL,
  savingType  CHAR(8) NOT NULL,
  openDate  DATETIME NOT NULL,
  openMoney  MONEY NOT NULL,
  balance  MONEY NOT NULL,
  pass CHAR(6) NOT NULL,
  IsReportLoss BIT  NOT NULL,
  customerID INT NOT NULL
)
GO

CREATE TABLE transInfo  --交易信息表
(
  transDate  DATETIME NOT NULL,
  transType  CHAR(4) NOT NULL,
  cardID  CHAR(19) NOT NULL,
  transMoney  MONEY NOT NULL,
  remark  TEXT   
)
GO

/*$$$$$$$$$$$$$加约束$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/* userInfo表的约束
customerID	顾客编号	自动编号（标识列），从1开始，主键
customerName	开户名	必填
PID	身份证号	必填，只能是18位或15位，身份证号唯一约束
telephone	联系电话	必填，格式为xxxx-xxxxxxxx或手机号13位
address	居住地址	可选输入
*/
ALTER TABLE userInfo
  ADD CONSTRAINT PK_customerID PRIMARY KEY(customerID),
      CONSTRAINT CK_PID CHECK( len(PID)=18 or len(PID)=15 ),
      CONSTRAINT UQ_PID UNIQUE(PID),
      CONSTRAINT CK_telephone CHECK( telephone like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or telephone like '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or len(telephone)=13 )
GO

/*cardInfo表的约束
cardID	卡号	必填，主健 , 银行的卡号规则和电话号码一样，一般前8位代表特殊含义，
        如某总行某支行等。假定该行要求其营业厅的卡号格式为：1010 3576 xxxx xxx开始
curType	货币	必填，默认为RMB
savingType	存款种类	活期/定活两便/定期
openDate	开户日期	必填，默认为系统当前日期
openMoney	开户金额	必填，不低于1元
balance	余额	必填，不低于1元,否则将销户
pass	密码	必填，6位数字，默认为6个8
IsReportLoss	是否挂失  必填，是/否值，默认为”否”
customerID	顾客编号	必填，表示该卡对应的顾客编号，一位顾客可以办理多张卡
*/
ALTER TABLE cardInfo
  ADD CONSTRAINT  PK_cardID  PRIMARY KEY(cardID),
      CONSTRAINT  CK_cardID  CHECK(cardID LIKE '1010 3576 [0-9][0-9][0-9][0-9] [0-9][0-9][0-9][0-9]'),
      CONSTRAINT  DF_curType  DEFAULT('RMB') FOR curType,
      CONSTRAINT  CK_savingType  CHECK(savingType IN ('活期','定活两便','定期')),
      CONSTRAINT  DF_openDate  DEFAULT(getdate()) FOR openDate,
      CONSTRAINT  CK_openMoney  CHECK(openMoney>=1),
      CONSTRAINT  CK_balance  CHECK(balance>=1),
      CONSTRAINT  CK_pass  CHECK(pass LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
      CONSTRAINT  DF_pass  DEFAULT('888888') FOR pass,
      CONSTRAINT  DF_IsReportLoss DEFAULT(0) FOR IsReportLoss,
      CONSTRAINT  FK_customerID FOREIGN KEY(customerID) REFERENCES userInfo(customerID)
GO

/* transInfo表的约束
transType       必填，只能是存入/支取 
cardID	卡号	必填，外健，可重复索引
transMoney	交易金额	必填，大于0
transDate	交易日期	必填，默认为系统当前日期
remark	备注	可选输入，其他说明
*/

ALTER TABLE transInfo
  ADD CONSTRAINT  CK_transType  CHECK(transType IN ('存入','支取')),
      CONSTRAINT  FK_cardID  FOREIGN KEY(cardID) REFERENCES cardInfo(cardID),
      CONSTRAINT  CK_transMoney  CHECK(transMoney>0),
      CONSTRAINT  DF_transDATE DEFAULT(getdate()) FOR transDate
GO

/*$$$$$$$$$$$$$插入测试数据$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/*
张三开户，身份证：123456789012345，电话：010-67898978，地址：北京海淀 
   开户金额：1000 活期   卡号：1010 3576 1234 5678
李四开户，身份证：321245678912345678，电话：0478-44443333，
   开户金额： 1  定期 卡号：1010 3576 1212 1134
*/
SET NOCOUNT ON  --不显示受影响的条数信息
INSERT INTO userInfo(customerName,PID,telephone,address )
     VALUES('张三','123456789012345','010-67898978','北京海淀')
INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
     VALUES('1010 3576 1234 5678','活期',1000,1000,1)

INSERT INTO userInfo(customerName,PID,telephone)
     VALUES('李四','321245678912345678','0478-44443333')
INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
     VALUES('1010 3576 1212 1134','定期',1,1,2)
SELECT * FROM userInfo
SELECT * FROM cardInfo

GO
/*
张三的卡号（1010 3576 1234 5678）取款900元，李四的卡号（1010 3576 1212 1134）存款5000元，要求保存交易记录，以便客户查询和银行业务统计。
说明：当存钱或取钱（如300元）时候，会往交易信息表（transInfo）中添加一条交易记录，
      同时应更新银行卡信息表（cardInfo）中的现有余额（如增加或减少500元）
*/
/*--------------交易信息表插入交易记录--------------------------*/
INSERT INTO transInfo(transType,cardID,transMoney) 
      VALUES('支取','1010 3576 1234 5678',900)  
/*-------------更新银行卡信息表中的现有余额-------------------*/
UPDATE cardInfo SET balance=balance-900 WHERE cardID='1010 3576 1234 5678'

/*--------------交易信息表插入交易记录--------------------------*/
INSERT INTO transInfo(transType,cardID,transMoney) 
      VALUES('存入','1010 3576 1212 1134',5000)   
/*-------------更新银行卡信息表中的现有余额-------------------*/
UPDATE cardInfo SET balance=balance+5000 WHERE cardID='1010 3576 1212 1134'
GO

/*--------检查测试数据是否正确---------*/
SELECT * FROM cardInfo
SELECT * FROM transInfo

/*$$$$$$$$$$$$$常规业务操作$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/*---------修改密码-----*/
--1.张三（卡号为1010 3576 1234 5678）修改银行卡密码为123456
--2.李四（卡号为1010 3576 1212 1134）修改银行卡密码为123123
update cardInfo set pass='123456' WHERE cardID='1010 3576 1234 5678' 
update cardInfo set pass='123123' WHERE cardID='1010 3576 1212 1134' 
SELECT * FROM cardInfo
/*---------挂失帐号---------*/
--李四（卡号为1010 3576 1212 1134）因银行卡丢失，申请挂失
update cardInfo set IsReportLoss=1 WHERE cardID='1010 3576 1212 1134' 
SELECT * FROM cardInfo
GO
/*--------查询余额3000~6000之间的定期卡号,显示该卡相关信息-----------------*/
SELECT * FROM cardInfo WHERE ((balance between 3000 and 6000) and (savingType='定期') )
/*--------统计银行的资金流通余额和盈利结算------------------------------*/
--统计说明:存款代表资金流入,取款代表资金.假定存款利率为千分之3,贷款利率为千分之8
DECLARE @inMoney money
DECLARE @outMoney money
DECLARE @profit money
SELECT * FROM transInfo 
SELECT @inMoney=sum(transMoney) FROM transInfo WHERE (transType='存入')
SELECT @outMoney=sum(transMoney) FROM transInfo WHERE (transType='支取')
print '银行流通余额总计为:'+ convert(varchar(20),@inMoney-@outMoney)+'RMB'
set @profit=@outMoney*0.008-@inMoney*0.003
print '盈利结算为:'+ convert(varchar(20),@profit)+'RMB'
GO
/*--------查询本周开户的卡号,显示该卡相关信息-----------------*/
SELECT * FROM cardInfo WHERE (DATEDIFF(Day,getDate(),openDate)<DATEPART(weekday,openDate))
/*---------查询本月交易金额最高的卡号----------------------*/
SELECT * FROM transInfo
SELECT DISTINCT cardID FROM transInfo WHERE  transMoney=(SELECT Max(transMoney) FROM transInfo)
/*---------查询挂失帐号的客户信息---------------------*/
SELECT customerName as 客户姓名,telephone as 联系电话 FROM userInfo 
    WHERE customerID IN (SELECT customerID FROM cardInfo WHERE IsReportLoss=1)
/*------催款提醒：例如某种业务的需要，每个月末，如果发现用户帐上余额少于200元，将致电催款。---*/
SELECT customerName as 客户姓名,telephone as 联系电话,balance as 帐上余额 
      FROM userInfo INNER JOIN cardInfo ON  userInfo.customerID=cardInfo.customerID WHERE balance<200
/*$$$$$$$$$$$$$索引和视图$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.创建索引：给交易表的卡号cardID字段创建重复索引
create NONCLUSTERED INDEX index_cardID ON transInfo(cardID)WITH FILLFACTOR=70
--2.按指定索引查询 张三（卡号为1010 3576 1212 1134）的交易记录
GO
SELECT * FROM transInfo (INDEX=index_cardID) WHERE cardID='1010 3576 1234 5678'
GO
--3.创建视图：为了向客户显示信息友好,查询各表要求字段全为中文字段名。
create VIEW view_userInfo  --银行卡信息表视图
  AS 
    select customerID as 客户编号,customerName as 开户名, PID as 身份证号,
        telephone as 电话号码,address as 居住地址  from userInfo
GO

create VIEW view_cardInfo  --银行卡信息表视图
  AS 
    select cardID as 卡号,curType as 货币种类, savingType as 存款类型,openDate as 开户日期,
       balance as 余额,pass 密码,IsReportLoss as 是否挂失,customerID as 客户编号  from cardInfo 
GO

create VIEW view_transInfo  --交易信息表视图
  AS 
    select transDate as 交易日期,transType as 交易类型, cardID as 卡号,transMoney as 交易金额,
      remark as 备注  from transInfo 
GO
 
/*$$$$$$$$$$$$$触发器$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--改进上述的存款或取款语句，当存钱或取钱（如500元）时候，会往交易信息表transInfo中添加一条交易记录，同时会自动更新用户信息表：userInfo中的现有金额的变化（如增加/减少500元）
  --drop trigger trig_trans
CREATE TRIGGER trig_trans ON transInfo FOR INSERT
  AS
    DECLARE @myTransType char(4),@outMoney MONEY,@myCardID char(19)
    SELECT @myTransType=transType,@outMoney=transMoney ,@myCardID=cardID FROM inserted
    DECLARE @mybalance money
    SELECT @mybalance=balance FROM cardInfo WHERE cardID=@myCardID
    if (@myTransType='支取') 
       if (@mybalance>=@outMoney+1)
           update cardInfo set balance=balance-@outMoney WHERE cardID=@myCardID
       else
          begin
            raiserror ('交易失败！余额不足！',16,1)
            rollback tran
            print '卡号'+@myCardID+'  余额：'+convert(varchar(20),@mybalance)   
            return
          end
    else
         update cardInfo set balance=balance+@outMoney WHERE cardID=@myCardID
    print '交易成功！交易金额：'+convert(varchar(20),@outMoney)
    SELECT @mybalance=balance FROM cardInfo WHERE cardID=@myCardID
    print '卡号'+@myCardID+'  余额：'+convert(varchar(20),@mybalance)   
GO
--测试触发器：张三的卡号支取1000，李四的卡号存入200
 --现实中的取款机依靠读卡器读出张三的卡号,这里根据张三的名字查出考号来模拟
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='张三'
INSERT INTO transInfo(transType,cardID,transMoney) VALUES('支取',@card,1000)
GO
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='李四'
INSERT INTO transInfo(transType,cardID,transMoney) VALUES('存入',@card,200)
GO

/*$$$$$$$$$$$$$$$$$$$$$$存储过程$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.取钱或存钱的存储过程
  --drop proc proc_takeMoney
create procedure proc_takeMoney @card char(19),@m money,@type char(4),@inputPass char(6)=''
 AS
   print '交易正进行,请稍后......'
   if (@type='支取')
      if ((SELECT pass FROM cardInfo WHERE cardID=@card)<>@inputPass )
         begin
           raiserror ('密码错误!',16,1)
           return 
         end
   INSERT INTO transInfo(transType,cardID,transMoney) VALUES(@type,@card,@m)
GO
--2.调用存储过程取钱或存钱 张三取300，李四存500
 --现实中的取款机依靠读卡器读出张三的卡号,这里根据张三的名字查出考号来模拟
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='张三'
EXEC proc_takeMoney @card,300 ,'支取','123456' 
GO

declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='李四'
EXEC proc_takeMoney @card,500 ,'存入'
select * from view_cardInfo
select * from view_transInfo
GO
--3.产生随机卡号的存储过程(一般用当前月份数\当前秒数\当前毫秒数乘以一定的系数作为随机种子)
  --drop proc proc_randCardID
create procedure proc_randCardID @randCardID char(19) OUTPUT
  AS
    DECLARE @r numeric(15,8) 
    DECLARE @tempStr  char(10)
    SELECT  @r=RAND((DATEPART(mm, GETDATE()) * 100000 )+ (DATEPART(ss, GETDATE()) * 1000 )
                  + DATEPART(ms, GETDATE()) )
    set @tempStr=convert(char(10),@r) --产生0.xxxxxxxx的数字,我们需要小数点后的八位数字 
    set @randCardID='1010 3576 '+SUBSTRING(@tempStr,3,4)+' '+SUBSTRING(@tempStr,7,4)  --组合为规定格式的卡号
GO
--4.测试产生随机卡号
DECLARE @mycardID char(19) 
EXECUTE proc_randCardID @mycardID OUTPUT
print '产生的随机卡号为：'+@mycardID
GO
--5.开户的存储过程
   --drop proc proc_openAccount
create procedure proc_openAccount @customerName char(8),@PID char(18),@telephone char(13)
     ,@openMoney money,@savingType char(8),@address varchar(50)='' 
  AS
     DECLARE @mycardID char(19),@cur_customerID int 
     --调用产生随机卡号的存储过程获得随机卡号
     EXECUTE proc_randCardID @mycardID OUTPUT
     while  exists(SELECT * FROM cardInfo WHERE cardID=@mycardID) 
        EXECUTE proc_randCardID @mycardID OUTPUT
     print '尊敬的客户,开户成功!系统为您产生的随机卡号为:'+@mycardID
     print '开户日期'+convert(char(10),getdate(),111)+'  开户金额:'+convert(varchar(20),@openMoney)
     IF not exists(select * from userInfo where PID=@PID)
       INSERT INTO userInfo(customerName,PID,telephone,address )
          VALUES(@customerName,@PID,@telephone,@address) 
     select @cur_customerID=customerID from userInfo where PID=@PID
     INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
         VALUES(@mycardID,@savingType,@openMoney,@openMoney,@cur_customerID)
     
GO

--6.调用存储过程重新开户
EXEC proc_openAccount '王五','334456889012678','2222-63598978',1000,'活期','河南新乡' 
EXEC proc_openAccount '赵二','213445678912342222','0760-44446666',1,'定期' 
select * from view_userInfo
select * from view_cardInfo
GO

/*$$$$$$$$$$$$$$$$$$$$$$事   务$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.转帐的事务存储过程
create procedure proc_transfer @card1 char(19),@card2 char(19),@outmoney money
 AS
   begin tran
     print '开始转帐,请稍后......'
     DECLARE @errors int
     set @errors=0
     INSERT INTO transInfo(transType,cardID,transMoney) VALUES('支取',@card1,@outmoney)
     set @errors=@errors+@@error
     INSERT INTO transInfo(transType,cardID,transMoney) VALUES('存入',@card2,@outmoney)
     set @errors=@errors+@@error
     if (@errors>0)
        begin
          print '转帐失败！'
          rollback tran
        end
     else
        begin
          print '转帐成功！'
          commit tran
        end
GO

--2.测试上述事务存储过程
--从李四的帐户转帐2000到张三的帐户
--同上一样,现实中的取款机依靠读卡器读出张三/李四的卡号,这里根据张三/李四的名字查出考号来模拟
declare @card1 char(19),@card2 char(19)
select @card1=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='李四'
select @card2=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='张三'
--调用上述事务过程转帐
EXEC proc_transfer @card1,@card2,2000

select * from view_userInfo
select * from view_cardInfo
select * from view_transInfo
GO
/*$$$$$$$$$$$$$$$$$$$$$$安    全$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.添加SQL登录帐号
If not exists(SELECT * FROM master.dbo.syslogins WHERE loginname='sysAdmin')
    begin
      EXEC sp_addlogin 'sysAdmin', '1234'    --添加SQL登录帐号
      EXEC   sp_defaultdb  'sysAdmin' , 'bankDB' --修改登录的默认数据库为bankDB
    end
  go
--2.创建数据库用户 
  EXEC sp_grantdbaccess  'sysAdmin', 'sysAdminDBUser'
  GO
--3.--------给数据库用户授权 
  --为sysAdminDBUser分配对象权限(增删改查的权限)
  GRANT SELECT,insert,update,delete,select  ON transInfo TO sysAdminDBUser    
  GRANT SELECT,insert,update,delete,select  ON userInfo TO sysAdminDBUser   
  GRANT SELECT,insert,update,delete,select  ON cardInfo TO sysAdminDBUser    
GO
 



    