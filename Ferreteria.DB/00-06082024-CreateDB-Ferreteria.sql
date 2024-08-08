if not exists (select 1 from sys.databases where name like 'Ferreteria')
begin
	create database Ferreteria
end