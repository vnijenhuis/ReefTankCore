/* Maak de tabellen en contraints aan. */

    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEABE0F4386734BC0]') AND parent_object_id = OBJECT_ID('Creature'))
alter table Creature  drop constraint FKEABE0F4386734BC0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33A412F9E4C1AE07]') AND parent_object_id = OBJECT_ID('CreatureTag'))
alter table CreatureTag  drop constraint FK33A412F9E4C1AE07


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33A412F9D008FFC1]') AND parent_object_id = OBJECT_ID('CreatureTag'))
alter table CreatureTag  drop constraint FK33A412F9D008FFC1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK564A388A8EDE9D7]') AND parent_object_id = OBJECT_ID('CreatureReference'))
alter table CreatureReference  drop constraint FK564A388A8EDE9D7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK564A388D008FFC1]') AND parent_object_id = OBJECT_ID('CreatureReference'))
alter table CreatureReference  drop constraint FK564A388D008FFC1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK34994B28D4B87A92]') AND parent_object_id = OBJECT_ID('Genus'))
alter table Genus  drop constraint FK34994B28D4B87A92


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA156120D3805368]') AND parent_object_id = OBJECT_ID('Subcategory'))
alter table Subcategory  drop constraint FKFA156120D3805368


    if exists (select * from dbo.sysobjects where id = object_id(N'Creature') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Creature

    if exists (select * from dbo.sysobjects where id = object_id(N'CreatureTag') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CreatureTag

    if exists (select * from dbo.sysobjects where id = object_id(N'CreatureReference') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CreatureReference

    if exists (select * from dbo.sysobjects where id = object_id(N'Genus') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Genus

    if exists (select * from dbo.sysobjects where id = object_id(N'Subcategory') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Subcategory

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Tag') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tag

    if exists (select * from dbo.sysobjects where id = object_id(N'Reference') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Reference

    create table Creature (
        Id UNIQUEIDENTIFIER not null,
       Type NVARCHAR(255) not null,
       CommonName NVARCHAR(255) null,
       Description nvarchar(2000) null,
       Species NVARCHAR(255) null,
       Origin NVARCHAR(255) null,
       Genus UNIQUEIDENTIFIER null,
       Length INT null,
       Volume INT null,
       Suitability INT null,
       ReefCompatability INT null,
       Temperament INT null,
       Hardiness INT null,
       Difficulty NVARCHAR(255) null,
       DifficultyDescription NVARCHAR(255) null,
       WaterMovement NVARCHAR(255) null,
       Lighting NVARCHAR(255) null,
       Fragmenting NVARCHAR(255) null,
       MinimumPh DOUBLE PRECISION null,
       MaximumPh DOUBLE PRECISION null,
       MinimumCalciumPpm INT null,
       MaximumCalciumPpm INT null,
       MinimumTemperature DOUBLE PRECISION null,
       MaximumTemperature DOUBLE PRECISION null,
       primary key (Id)
    )

    create table CreatureTag (
        Id INT IDENTITY NOT NULL,
       TagId UNIQUEIDENTIFIER null,
       CreatureId UNIQUEIDENTIFIER null,
       primary key (Id)
    )

    create table CreatureReference (
        Id INT IDENTITY NOT NULL,
       ReferenceId UNIQUEIDENTIFIER null,
       CreatureId UNIQUEIDENTIFIER null,
       primary key (Id)
    )

    create table Genus (
        Id UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Subcategory UNIQUEIDENTIFIER null,
       primary key (Id)
    )

    create table Subcategory (
        Id UNIQUEIDENTIFIER not null,
       LatinName NVARCHAR(255) null,
       ScientificName NVARCHAR(255) null,
       Description nvarchar(1000) null,
       Category UNIQUEIDENTIFIER null,
       primary key (Id)
    )

    create table Category (
        Id UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table Tag (
        Id UNIQUEIDENTIFIER not null,
       Title NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       TagType INT null,
       primary key (Id)
    )

    create table Reference (
        Id UNIQUEIDENTIFIER not null,
       Website NVARCHAR(255) null,
       Title NVARCHAR(255) null,
       Source NVARCHAR(255) null,
       DateLastUpdated DATETIME null,
       primary key (Id)
    )

    alter table Creature 
        add constraint FKEABE0F4386734BC0 
        foreign key (Genus) 
        references Genus

    alter table CreatureTag 
        add constraint FK33A412F9E4C1AE07 
        foreign key (TagId) 
        references Tag

    alter table CreatureTag 
        add constraint FK33A412F9D008FFC1 
        foreign key (CreatureId) 
        references Creature

    alter table CreatureReference 
        add constraint FK564A388A8EDE9D7 
        foreign key (ReferenceId) 
        references Reference

    alter table CreatureReference 
        add constraint FK564A388D008FFC1 
        foreign key (CreatureId) 
        references Creature

    alter table Genus 
        add constraint FK34994B28D4B87A92 
        foreign key (Subcategory) 
        references Subcategory

    alter table Subcategory 
        add constraint FKFA156120D3805368 
        foreign key (Category) 
        references Category
