/*$$$$$$$$$$$$$�����ļ���$$$$$$$$$$$$$$$$$$*/
USE master
GO

EXEC xp_cmdshell 'mkdir d:\bank', NO_OUTPUT   

/*$$$$$$$$$$$$$����$$$$$$$$$$$$$$$$$$$$$$$$*/
--�������ݿ��Ƿ���ڣ����Ϊ�棬ɾ�������ݿ�--
IF exists(SELECT * FROM sysdatabases WHERE name='bankDB')
  DROP DATABASE bankDB
GO
--��������bankDB
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
/*$$$$$$$$$$$$$����$$$$$$$$$$$$$$$$$$$$$$$$*/

USE bankDB
GO

CREATE TABLE userInfo  --�û���Ϣ��
(
  customerID INT IDENTITY(1,1),
  customerName CHAR(8) NOT NULL,
  PID CHAR(18) NOT NULL,
  telephone CHAR(13) NOT NULL,
  address VARCHAR(50)
)
GO

CREATE TABLE cardInfo  --���п���Ϣ��
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

CREATE TABLE transInfo  --������Ϣ��
(
  transDate  DATETIME NOT NULL,
  transType  CHAR(4) NOT NULL,
  cardID  CHAR(19) NOT NULL,
  transMoney  MONEY NOT NULL,
  remark  TEXT   
)
GO

/*$$$$$$$$$$$$$��Լ��$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/* userInfo���Լ��
customerID	�˿ͱ��	�Զ���ţ���ʶ�У�����1��ʼ������
customerName	������	����
PID	���֤��	���ֻ����18λ��15λ�����֤��ΨһԼ��
telephone	��ϵ�绰	�����ʽΪxxxx-xxxxxxxx���ֻ���13λ
address	��ס��ַ	��ѡ����
*/
ALTER TABLE userInfo
  ADD CONSTRAINT PK_customerID PRIMARY KEY(customerID),
      CONSTRAINT CK_PID CHECK( len(PID)=18 or len(PID)=15 ),
      CONSTRAINT UQ_PID UNIQUE(PID),
      CONSTRAINT CK_telephone CHECK( telephone like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or telephone like '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or len(telephone)=13 )
GO

/*cardInfo���Լ��
cardID	����	������� , ���еĿ��Ź���͵绰����һ����һ��ǰ8λ�������⺬�壬
        ��ĳ����ĳ֧�еȡ��ٶ�����Ҫ����Ӫҵ���Ŀ��Ÿ�ʽΪ��1010 3576 xxxx xxx��ʼ
curType	����	���Ĭ��ΪRMB
savingType	�������	����/��������/����
openDate	��������	���Ĭ��Ϊϵͳ��ǰ����
openMoney	�������	���������1Ԫ
balance	���	���������1Ԫ,��������
pass	����	���6λ���֣�Ĭ��Ϊ6��8
IsReportLoss	�Ƿ��ʧ  �����/��ֵ��Ĭ��Ϊ����
customerID	�˿ͱ��	�����ʾ�ÿ���Ӧ�Ĺ˿ͱ�ţ�һλ�˿Ϳ��԰�����ſ�
*/
ALTER TABLE cardInfo
  ADD CONSTRAINT  PK_cardID  PRIMARY KEY(cardID),
      CONSTRAINT  CK_cardID  CHECK(cardID LIKE '1010 3576 [0-9][0-9][0-9][0-9] [0-9][0-9][0-9][0-9]'),
      CONSTRAINT  DF_curType  DEFAULT('RMB') FOR curType,
      CONSTRAINT  CK_savingType  CHECK(savingType IN ('����','��������','����')),
      CONSTRAINT  DF_openDate  DEFAULT(getdate()) FOR openDate,
      CONSTRAINT  CK_openMoney  CHECK(openMoney>=1),
      CONSTRAINT  CK_balance  CHECK(balance>=1),
      CONSTRAINT  CK_pass  CHECK(pass LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
      CONSTRAINT  DF_pass  DEFAULT('888888') FOR pass,
      CONSTRAINT  DF_IsReportLoss DEFAULT(0) FOR IsReportLoss,
      CONSTRAINT  FK_customerID FOREIGN KEY(customerID) REFERENCES userInfo(customerID)
GO

/* transInfo���Լ��
transType       ���ֻ���Ǵ���/֧ȡ 
cardID	����	����⽡�����ظ�����
transMoney	���׽��	�������0
transDate	��������	���Ĭ��Ϊϵͳ��ǰ����
remark	��ע	��ѡ���룬����˵��
*/

ALTER TABLE transInfo
  ADD CONSTRAINT  CK_transType  CHECK(transType IN ('����','֧ȡ')),
      CONSTRAINT  FK_cardID  FOREIGN KEY(cardID) REFERENCES cardInfo(cardID),
      CONSTRAINT  CK_transMoney  CHECK(transMoney>0),
      CONSTRAINT  DF_transDATE DEFAULT(getdate()) FOR transDate
GO

/*$$$$$$$$$$$$$�����������$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/*
�������������֤��123456789012345���绰��010-67898978����ַ���������� 
   ������1000 ����   ���ţ�1010 3576 1234 5678
���Ŀ��������֤��321245678912345678���绰��0478-44443333��
   ������ 1  ���� ���ţ�1010 3576 1212 1134
*/
SET NOCOUNT ON  --����ʾ��Ӱ���������Ϣ
INSERT INTO userInfo(customerName,PID,telephone,address )
     VALUES('����','123456789012345','010-67898978','��������')
INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
     VALUES('1010 3576 1234 5678','����',1000,1000,1)

INSERT INTO userInfo(customerName,PID,telephone)
     VALUES('����','321245678912345678','0478-44443333')
INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
     VALUES('1010 3576 1212 1134','����',1,1,2)
SELECT * FROM userInfo
SELECT * FROM cardInfo

GO
/*
�����Ŀ��ţ�1010 3576 1234 5678��ȡ��900Ԫ�����ĵĿ��ţ�1010 3576 1212 1134�����5000Ԫ��Ҫ�󱣴潻�׼�¼���Ա�ͻ���ѯ������ҵ��ͳ�ơ�
˵��������Ǯ��ȡǮ����300Ԫ��ʱ�򣬻���������Ϣ��transInfo�������һ�����׼�¼��
      ͬʱӦ�������п���Ϣ��cardInfo���е������������ӻ����500Ԫ��
*/
/*--------------������Ϣ����뽻�׼�¼--------------------------*/
INSERT INTO transInfo(transType,cardID,transMoney) 
      VALUES('֧ȡ','1010 3576 1234 5678',900)  
/*-------------�������п���Ϣ���е��������-------------------*/
UPDATE cardInfo SET balance=balance-900 WHERE cardID='1010 3576 1234 5678'

/*--------------������Ϣ����뽻�׼�¼--------------------------*/
INSERT INTO transInfo(transType,cardID,transMoney) 
      VALUES('����','1010 3576 1212 1134',5000)   
/*-------------�������п���Ϣ���е��������-------------------*/
UPDATE cardInfo SET balance=balance+5000 WHERE cardID='1010 3576 1212 1134'
GO

/*--------�����������Ƿ���ȷ---------*/
SELECT * FROM cardInfo
SELECT * FROM transInfo

/*$$$$$$$$$$$$$����ҵ�����$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
/*---------�޸�����-----*/
--1.����������Ϊ1010 3576 1234 5678���޸����п�����Ϊ123456
--2.���ģ�����Ϊ1010 3576 1212 1134���޸����п�����Ϊ123123
update cardInfo set pass='123456' WHERE cardID='1010 3576 1234 5678' 
update cardInfo set pass='123123' WHERE cardID='1010 3576 1212 1134' 
SELECT * FROM cardInfo
/*---------��ʧ�ʺ�---------*/
--���ģ�����Ϊ1010 3576 1212 1134�������п���ʧ�������ʧ
update cardInfo set IsReportLoss=1 WHERE cardID='1010 3576 1212 1134' 
SELECT * FROM cardInfo
GO
/*--------��ѯ���3000~6000֮��Ķ��ڿ���,��ʾ�ÿ������Ϣ-----------------*/
SELECT * FROM cardInfo WHERE ((balance between 3000 and 6000) and (savingType='����') )
/*--------ͳ�����е��ʽ���ͨ����ӯ������------------------------------*/
--ͳ��˵��:�������ʽ�����,ȡ������ʽ�.�ٶ��������Ϊǧ��֮3,��������Ϊǧ��֮8
DECLARE @inMoney money
DECLARE @outMoney money
DECLARE @profit money
SELECT * FROM transInfo 
SELECT @inMoney=sum(transMoney) FROM transInfo WHERE (transType='����')
SELECT @outMoney=sum(transMoney) FROM transInfo WHERE (transType='֧ȡ')
print '������ͨ����ܼ�Ϊ:'+ convert(varchar(20),@inMoney-@outMoney)+'RMB'
set @profit=@outMoney*0.008-@inMoney*0.003
print 'ӯ������Ϊ:'+ convert(varchar(20),@profit)+'RMB'
GO
/*--------��ѯ���ܿ����Ŀ���,��ʾ�ÿ������Ϣ-----------------*/
SELECT * FROM cardInfo WHERE (DATEDIFF(Day,getDate(),openDate)<DATEPART(weekday,openDate))
/*---------��ѯ���½��׽����ߵĿ���----------------------*/
SELECT * FROM transInfo
SELECT DISTINCT cardID FROM transInfo WHERE  transMoney=(SELECT Max(transMoney) FROM transInfo)
/*---------��ѯ��ʧ�ʺŵĿͻ���Ϣ---------------------*/
SELECT customerName as �ͻ�����,telephone as ��ϵ�绰 FROM userInfo 
    WHERE customerID IN (SELECT customerID FROM cardInfo WHERE IsReportLoss=1)
/*------�߿����ѣ�����ĳ��ҵ�����Ҫ��ÿ����ĩ����������û������������200Ԫ�����µ�߿---*/
SELECT customerName as �ͻ�����,telephone as ��ϵ�绰,balance as ������� 
      FROM userInfo INNER JOIN cardInfo ON  userInfo.customerID=cardInfo.customerID WHERE balance<200
/*$$$$$$$$$$$$$��������ͼ$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.���������������ױ�Ŀ���cardID�ֶδ����ظ�����
create NONCLUSTERED INDEX index_cardID ON transInfo(cardID)WITH FILLFACTOR=70
--2.��ָ��������ѯ ����������Ϊ1010 3576 1212 1134���Ľ��׼�¼
GO
SELECT * FROM transInfo (INDEX=index_cardID) WHERE cardID='1010 3576 1234 5678'
GO
--3.������ͼ��Ϊ����ͻ���ʾ��Ϣ�Ѻ�,��ѯ����Ҫ���ֶ�ȫΪ�����ֶ�����
create VIEW view_userInfo  --���п���Ϣ����ͼ
  AS 
    select customerID as �ͻ����,customerName as ������, PID as ���֤��,
        telephone as �绰����,address as ��ס��ַ  from userInfo
GO

create VIEW view_cardInfo  --���п���Ϣ����ͼ
  AS 
    select cardID as ����,curType as ��������, savingType as �������,openDate as ��������,
       balance as ���,pass ����,IsReportLoss as �Ƿ��ʧ,customerID as �ͻ����  from cardInfo 
GO

create VIEW view_transInfo  --������Ϣ����ͼ
  AS 
    select transDate as ��������,transType as ��������, cardID as ����,transMoney as ���׽��,
      remark as ��ע  from transInfo 
GO
 
/*$$$$$$$$$$$$$������$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--�Ľ������Ĵ���ȡ����䣬����Ǯ��ȡǮ����500Ԫ��ʱ�򣬻���������Ϣ��transInfo�����һ�����׼�¼��ͬʱ���Զ������û���Ϣ��userInfo�е����н��ı仯��������/����500Ԫ��
  --drop trigger trig_trans
CREATE TRIGGER trig_trans ON transInfo FOR INSERT
  AS
    DECLARE @myTransType char(4),@outMoney MONEY,@myCardID char(19)
    SELECT @myTransType=transType,@outMoney=transMoney ,@myCardID=cardID FROM inserted
    DECLARE @mybalance money
    SELECT @mybalance=balance FROM cardInfo WHERE cardID=@myCardID
    if (@myTransType='֧ȡ') 
       if (@mybalance>=@outMoney+1)
           update cardInfo set balance=balance-@outMoney WHERE cardID=@myCardID
       else
          begin
            raiserror ('����ʧ�ܣ����㣡',16,1)
            rollback tran
            print '����'+@myCardID+'  ��'+convert(varchar(20),@mybalance)   
            return
          end
    else
         update cardInfo set balance=balance+@outMoney WHERE cardID=@myCardID
    print '���׳ɹ������׽�'+convert(varchar(20),@outMoney)
    SELECT @mybalance=balance FROM cardInfo WHERE cardID=@myCardID
    print '����'+@myCardID+'  ��'+convert(varchar(20),@mybalance)   
GO
--���Դ������������Ŀ���֧ȡ1000�����ĵĿ��Ŵ���200
 --��ʵ�е�ȡ����������������������Ŀ���,����������������ֲ��������ģ��
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
INSERT INTO transInfo(transType,cardID,transMoney) VALUES('֧ȡ',@card,1000)
GO
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
INSERT INTO transInfo(transType,cardID,transMoney) VALUES('����',@card,200)
GO

/*$$$$$$$$$$$$$$$$$$$$$$�洢����$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.ȡǮ���Ǯ�Ĵ洢����
  --drop proc proc_takeMoney
create procedure proc_takeMoney @card char(19),@m money,@type char(4),@inputPass char(6)=''
 AS
   print '����������,���Ժ�......'
   if (@type='֧ȡ')
      if ((SELECT pass FROM cardInfo WHERE cardID=@card)<>@inputPass )
         begin
           raiserror ('�������!',16,1)
           return 
         end
   INSERT INTO transInfo(transType,cardID,transMoney) VALUES(@type,@card,@m)
GO
--2.���ô洢����ȡǮ���Ǯ ����ȡ300�����Ĵ�500
 --��ʵ�е�ȡ����������������������Ŀ���,����������������ֲ��������ģ��
declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
EXEC proc_takeMoney @card,300 ,'֧ȡ','123456' 
GO

declare @card char(19)
select @card=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
EXEC proc_takeMoney @card,500 ,'����'
select * from view_cardInfo
select * from view_transInfo
GO
--3.����������ŵĴ洢����(һ���õ�ǰ�·���\��ǰ����\��ǰ����������һ����ϵ����Ϊ�������)
  --drop proc proc_randCardID
create procedure proc_randCardID @randCardID char(19) OUTPUT
  AS
    DECLARE @r numeric(15,8) 
    DECLARE @tempStr  char(10)
    SELECT  @r=RAND((DATEPART(mm, GETDATE()) * 100000 )+ (DATEPART(ss, GETDATE()) * 1000 )
                  + DATEPART(ms, GETDATE()) )
    set @tempStr=convert(char(10),@r) --����0.xxxxxxxx������,������ҪС�����İ�λ���� 
    set @randCardID='1010 3576 '+SUBSTRING(@tempStr,3,4)+' '+SUBSTRING(@tempStr,7,4)  --���Ϊ�涨��ʽ�Ŀ���
GO
--4.���Բ����������
DECLARE @mycardID char(19) 
EXECUTE proc_randCardID @mycardID OUTPUT
print '�������������Ϊ��'+@mycardID
GO
--5.�����Ĵ洢����
   --drop proc proc_openAccount
create procedure proc_openAccount @customerName char(8),@PID char(18),@telephone char(13)
     ,@openMoney money,@savingType char(8),@address varchar(50)='' 
  AS
     DECLARE @mycardID char(19),@cur_customerID int 
     --���ò���������ŵĴ洢���̻���������
     EXECUTE proc_randCardID @mycardID OUTPUT
     while  exists(SELECT * FROM cardInfo WHERE cardID=@mycardID) 
        EXECUTE proc_randCardID @mycardID OUTPUT
     print '�𾴵Ŀͻ�,�����ɹ�!ϵͳΪ���������������Ϊ:'+@mycardID
     print '��������'+convert(char(10),getdate(),111)+'  �������:'+convert(varchar(20),@openMoney)
     IF not exists(select * from userInfo where PID=@PID)
       INSERT INTO userInfo(customerName,PID,telephone,address )
          VALUES(@customerName,@PID,@telephone,@address) 
     select @cur_customerID=customerID from userInfo where PID=@PID
     INSERT INTO cardInfo(cardID,savingType,openMoney,balance,customerID)
         VALUES(@mycardID,@savingType,@openMoney,@openMoney,@cur_customerID)
     
GO

--6.���ô洢�������¿���
EXEC proc_openAccount '����','334456889012678','2222-63598978',1000,'����','��������' 
EXEC proc_openAccount '�Զ�','213445678912342222','0760-44446666',1,'����' 
select * from view_userInfo
select * from view_cardInfo
GO

/*$$$$$$$$$$$$$$$$$$$$$$��   ��$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.ת�ʵ�����洢����
create procedure proc_transfer @card1 char(19),@card2 char(19),@outmoney money
 AS
   begin tran
     print '��ʼת��,���Ժ�......'
     DECLARE @errors int
     set @errors=0
     INSERT INTO transInfo(transType,cardID,transMoney) VALUES('֧ȡ',@card1,@outmoney)
     set @errors=@errors+@@error
     INSERT INTO transInfo(transType,cardID,transMoney) VALUES('����',@card2,@outmoney)
     set @errors=@errors+@@error
     if (@errors>0)
        begin
          print 'ת��ʧ�ܣ�'
          rollback tran
        end
     else
        begin
          print 'ת�ʳɹ���'
          commit tran
        end
GO

--2.������������洢����
--�����ĵ��ʻ�ת��2000���������ʻ�
--ͬ��һ��,��ʵ�е�ȡ���������������������/���ĵĿ���,�����������/���ĵ����ֲ��������ģ��
declare @card1 char(19),@card2 char(19)
select @card1=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
select @card2=cardID from cardInfo Inner Join userInfo ON 
   cardInfo.customerID=userInfo.customerID where customerName='����'
--���������������ת��
EXEC proc_transfer @card1,@card2,2000

select * from view_userInfo
select * from view_cardInfo
select * from view_transInfo
GO
/*$$$$$$$$$$$$$$$$$$$$$$��    ȫ$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
--1.���SQL��¼�ʺ�
If not exists(SELECT * FROM master.dbo.syslogins WHERE loginname='sysAdmin')
    begin
      EXEC sp_addlogin 'sysAdmin', '1234'    --���SQL��¼�ʺ�
      EXEC   sp_defaultdb  'sysAdmin' , 'bankDB' --�޸ĵ�¼��Ĭ�����ݿ�ΪbankDB
    end
  go
--2.�������ݿ��û� 
  EXEC sp_grantdbaccess  'sysAdmin', 'sysAdminDBUser'
  GO
--3.--------�����ݿ��û���Ȩ 
  --ΪsysAdminDBUser�������Ȩ��(��ɾ�Ĳ��Ȩ��)
  GRANT SELECT,insert,update,delete,select  ON transInfo TO sysAdminDBUser    
  GRANT SELECT,insert,update,delete,select  ON userInfo TO sysAdminDBUser   
  GRANT SELECT,insert,update,delete,select  ON cardInfo TO sysAdminDBUser    
GO
 



    