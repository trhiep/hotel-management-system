-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-07-03 16:19:25.102
-- tables
-- Table: Account
CREATE TABLE Account (
    AccountID int  NOT NULL IDENTITY(1, 1),
    Username varchar(50)  NOT NULL,
    Fullname varchar(100)  NOT NULL,
    Password varchar(255)  NOT NULL,
    PhoneNumber varchar(15)  NOT NULL,
    Email varchar(100)  NOT NULL,
    Address varchar(100)  NULL,
    RoleID int  NOT NULL,
    IsEnable bit  NOT NULL,
    CONSTRAINT UNQ_Account_Username UNIQUE (Username),
    CONSTRAINT UNQ_Account_Email UNIQUE (Email),
    CONSTRAINT Account_pk PRIMARY KEY  (AccountID)
);

-- Table: Bill
CREATE TABLE Bill (
    BillID int  NOT NULL IDENTITY(1, 1),
    RoomBookingID int  NULL,
    IsPaid bit  NOT NULL,
    CONSTRAINT Bill_pk PRIMARY KEY  (BillID)
);

-- Table: BillDetails
CREATE TABLE BillDetails (
    BillDetailsID int  NOT NULL IDENTITY(1, 1),
    BillID int  NOT NULL,
    Title varchar(100)  NOT NULL,
    Price float(2)  NOT NULL,
    Note varchar(500)  NULL,
    CONSTRAINT BillDetails_pk PRIMARY KEY  (BillDetailsID)
);

-- Table: BookingStatus
CREATE TABLE BookingStatus (
    BookingStatusID int  NOT NULL IDENTITY(1, 1),
    BookingStatusName varchar(50)  NOT NULL,
    CONSTRAINT UNQ_BookingStatus_Name UNIQUE (BookingStatusName),
    CONSTRAINT BookingStatus_pk PRIMARY KEY  (BookingStatusID)
);

-- Table: Customer
CREATE TABLE Customer (
    CustomerID int  NOT NULL IDENTITY(1, 1),
    CustomerName varchar(100)  NOT NULL,
    CitizenID varchar(20)  NOT NULL,
    PhoneNumber varchar(15)  NOT NULL,
    Email varchar(100)  NULL,
    IsLoyal bit  NOT NULL,
    IsAllowReceiveInformaton bit  NOT NULL,
    CONSTRAINT UNQ_Customer_CitizenID UNIQUE (CitizenID),
    CONSTRAINT UNQ_Customer_Phone UNIQUE (PhoneNumber),
    CONSTRAINT UNQ_Customer_Email UNIQUE (Email),
    CONSTRAINT Customer_pk PRIMARY KEY  (CustomerID)
);

-- Table: Facility
CREATE TABLE Facility (
    FacilityID int  NOT NULL IDENTITY(1, 1),
    FacilityName varchar(50)  NOT NULL,
    Price float(2)  NOT NULL,
    Description varchar(255)  NULL,
    CONSTRAINT Facility_pk PRIMARY KEY  (FacilityID)
);

-- Table: FacilityMaintenanceStatus
CREATE TABLE FacilityMaintenanceStatus (
    MaintenanceStatusID int  NOT NULL IDENTITY(1, 1),
    StatusName varchar(20)  NOT NULL,
    CONSTRAINT FacilityMaintenanceStatus_pk PRIMARY KEY  (MaintenanceStatusID)
);

-- Table: FacilityReport
CREATE TABLE FacilityReport (
    ReportID int  NOT NULL IDENTITY(1, 1),
    ReportDate datetime  NOT NULL,
    ImageLink varchar(max)  NOT NULL,
    RoomFacilityID int  NOT NULL,
    MaintenanceStatusID int  NOT NULL,
    CONSTRAINT FacilityReport_pk PRIMARY KEY  (ReportID)
);

-- Table: HotelRoom
CREATE TABLE HotelRoom (
    RoomID int  NOT NULL IDENTITY(1, 1),
    RoomNumber varchar(50)  NOT NULL,
    Price float(2)  NOT NULL,
    CONSTRAINT UNQ_HotelRoom_Number UNIQUE (RoomNumber),
    CONSTRAINT HotelRoom_pk PRIMARY KEY  (RoomID)
);

-- Table: MenuBooking
CREATE TABLE MenuBooking (
    BookingID int  NOT NULL IDENTITY(1, 1),
    CustomerID int  NOT NULL,
    ItemID int  NOT NULL,
    Quantity int  NOT NULL,
    IsDone bit  NOT NULL,
    CONSTRAINT CK_MenuBooking_Quantity CHECK (Quantity > 0),
    CONSTRAINT MenuBooking_pk PRIMARY KEY  (BookingID)
);

-- Table: MenuCategory
CREATE TABLE MenuCategory (
    CategoryID int  NOT NULL IDENTITY(1, 1),
    CategoryName varchar(100)  NOT NULL,
    CONSTRAINT MenuCategory_pk PRIMARY KEY  (CategoryID)
);

-- Table: MenuItem
CREATE TABLE MenuItem (
    ItemID int  NOT NULL IDENTITY(1, 1),
    CategoryID int  NOT NULL,
    ItemName varchar(50)  NOT NULL,
    Price float(2)  NOT NULL,
    IsAvaliable bit  NOT NULL,
    Description varchar(150)  NULL,
    CONSTRAINT MenuItem_pk PRIMARY KEY  (ItemID)
);

-- Table: Promotion
CREATE TABLE Promotion (
    PromotionID int  NOT NULL IDENTITY(1, 1),
    PromotionCode varchar(15)  NOT NULL,
    Title varchar(100)  NOT NULL,
    DiscountValue float(2)  NOT NULL,
    Quantity int  NOT NULL,
    PromotionTypeID int  NOT NULL,
    CreatedBy int  NOT NULL,
    StatusID int  NOT NULL,
    PromotionTargetID int  NOT NULL,
    CONSTRAINT CK_Promotion_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_Promotion_DiscountValue CHECK (DiscountValue > 0),
    CONSTRAINT Promotion_pk PRIMARY KEY  (PromotionID)
);

-- Table: PromotionCustomer
CREATE TABLE PromotionCustomer (
    PromotionCustomerID int  NOT NULL IDENTITY(1, 1),
    CustomerID int  NOT NULL,
    PromotionID int  NOT NULL,
    IsUsed bit  NOT NULL,
    CONSTRAINT PromotionCustomer_pk PRIMARY KEY  (PromotionCustomerID)
);

-- Table: PromotionHotelRoom
CREATE TABLE PromotionHotelRoom (
    PromotionRoomID int  NOT NULL IDENTITY(1, 1),
    RoomID int  NOT NULL,
    PromotionID int  NOT NULL,
    CONSTRAINT PromotionHotelRoom_pk PRIMARY KEY  (PromotionRoomID)
);

-- Table: PromotionStatus
CREATE TABLE PromotionStatus (
    PromotionStatusID int  NOT NULL IDENTITY(1, 1),
    StatusName varchar(50)  NOT NULL,
    CONSTRAINT PromotionStatus_pk PRIMARY KEY  (PromotionStatusID)
);

-- Table: PromotionTarget
CREATE TABLE PromotionTarget (
    PromotionTargetID int  NOT NULL IDENTITY(1, 1),
    TargetName varchar(50)  NOT NULL,
    CONSTRAINT PromotionTarget_pk PRIMARY KEY  (PromotionTargetID)
);

-- Table: PromotionType
CREATE TABLE PromotionType (
    PromotionTypeID int  NOT NULL IDENTITY(1, 1),
    TypeName varchar(50)  NOT NULL,
    CONSTRAINT PromotionType_pk PRIMARY KEY  (PromotionTypeID)
);

-- Table: ResetPasswordOTP
CREATE TABLE ResetPasswordOTP (
    OTPID int  NOT NULL IDENTITY(1, 1),
    AccountID int  NOT NULL,
    OTPString varchar(8)  NOT NULL,
    IsUsed bit  NOT NULL,
    GeneratedTime datetime  NOT NULL,
    CONSTRAINT ResetPasswordOTP_pk PRIMARY KEY  (OTPID)
);

-- Table: RestaurantBooking
CREATE TABLE RestaurantBooking (
    RestaurantBookingID int  NOT NULL IDENTITY(1, 1),
    CustomerID int  NOT NULL,
    TableID int  NOT NULL,
    CONSTRAINT RestaurantBooking_pk PRIMARY KEY  (RestaurantBookingID)
);

-- Table: RestaurantTable
CREATE TABLE RestaurantTable (
    TableID int  NOT NULL,
    Slot int  NOT NULL,
    CONSTRAINT CK_RestaurantTable_Slot CHECK (Slot > 0),
    CONSTRAINT RestaurantTable_pk PRIMARY KEY  (TableID)
);

-- Table: Role
CREATE TABLE Role (
    RoleID int  NOT NULL IDENTITY(1, 1),
    RoleName varchar(50)  NOT NULL,
    Salary float(10)  NOT NULL,
    CONSTRAINT Role_pk PRIMARY KEY  (RoleID)
);

-- Table: RoomBooking
CREATE TABLE RoomBooking (
    RoomBookingID int  NOT NULL IDENTITY(1, 1),
    AccountID int  NOT NULL,
    CustomerID int  NOT NULL,
    RoomID int  NOT NULL,
    BookDate datetime  NOT NULL,
    FromDate datetime  NOT NULL,
    ToDate datetime  NOT NULL,
    BookingStatusID int  NOT NULL,
    CONSTRAINT RoomBooking_pk PRIMARY KEY  (RoomBookingID)
);

-- Table: RoomFacility
CREATE TABLE RoomFacility (
    RoomFacilityID int  NOT NULL IDENTITY(1, 1),
    FacilityID int  NOT NULL,
    RoomID int  NOT NULL,
    Quantity int  NOT NULL,
    CONSTRAINT CK_RoomFacility_Quantity CHECK (Quantity > 0),
    CONSTRAINT RoomFacility_pk PRIMARY KEY  (RoomFacilityID)
);

-- foreign keys
-- Reference: Account_Role (table: Account)
ALTER TABLE Account ADD CONSTRAINT Account_Role
    FOREIGN KEY (RoleID)
    REFERENCES Role (RoleID);

-- Reference: BillDetails_Bill (table: BillDetails)
ALTER TABLE BillDetails ADD CONSTRAINT BillDetails_Bill
    FOREIGN KEY (BillID)
    REFERENCES Bill (BillID);

-- Reference: Bill_RoomBooking (table: Bill)
ALTER TABLE Bill ADD CONSTRAINT Bill_RoomBooking
    FOREIGN KEY (RoomBookingID)
    REFERENCES RoomBooking (RoomBookingID);

-- Reference: CategoryID (table: MenuItem)
ALTER TABLE MenuItem ADD CONSTRAINT CategoryID
    FOREIGN KEY (CategoryID)
    REFERENCES MenuCategory (CategoryID);

-- Reference: FacilityReport_FacilityMaintenanceStatus (table: FacilityReport)
ALTER TABLE FacilityReport ADD CONSTRAINT FacilityReport_FacilityMaintenanceStatus
    FOREIGN KEY (MaintenanceStatusID)
    REFERENCES FacilityMaintenanceStatus (MaintenanceStatusID);

-- Reference: FacilityReport_RoomFacilities (table: FacilityReport)
ALTER TABLE FacilityReport ADD CONSTRAINT FacilityReport_RoomFacilities
    FOREIGN KEY (RoomFacilityID)
    REFERENCES RoomFacility (RoomFacilityID);

-- Reference: MenuBooking_Customer (table: MenuBooking)
ALTER TABLE MenuBooking ADD CONSTRAINT MenuBooking_Customer
    FOREIGN KEY (CustomerID)
    REFERENCES Customer (CustomerID);

-- Reference: MenuBooking_MenuItem (table: MenuBooking)
ALTER TABLE MenuBooking ADD CONSTRAINT MenuBooking_MenuItem
    FOREIGN KEY (ItemID)
    REFERENCES MenuItem (ItemID);

-- Reference: OTPManager_Account (table: ResetPasswordOTP)
ALTER TABLE ResetPasswordOTP ADD CONSTRAINT OTPManager_Account
    FOREIGN KEY (AccountID)
    REFERENCES Account (AccountID);

-- Reference: PromotionCustomer_Customer (table: PromotionCustomer)
ALTER TABLE PromotionCustomer ADD CONSTRAINT PromotionCustomer_Customer
    FOREIGN KEY (CustomerID)
    REFERENCES Customer (CustomerID);

-- Reference: PromotionCustomer_Promotion (table: PromotionCustomer)
ALTER TABLE PromotionCustomer ADD CONSTRAINT PromotionCustomer_Promotion
    FOREIGN KEY (PromotionID)
    REFERENCES Promotion (PromotionID);

-- Reference: PromotionRoom_HotelRoom (table: PromotionHotelRoom)
ALTER TABLE PromotionHotelRoom ADD CONSTRAINT PromotionRoom_HotelRoom
    FOREIGN KEY (RoomID)
    REFERENCES HotelRoom (RoomID);

-- Reference: PromotionRoom_Promotion (table: PromotionHotelRoom)
ALTER TABLE PromotionHotelRoom ADD CONSTRAINT PromotionRoom_Promotion
    FOREIGN KEY (PromotionID)
    REFERENCES Promotion (PromotionID);

-- Reference: Promotion_Account (table: Promotion)
ALTER TABLE Promotion ADD CONSTRAINT Promotion_Account
    FOREIGN KEY (CreatedBy)
    REFERENCES Account (AccountID);

-- Reference: Promotion_PromotionStatus (table: Promotion)
ALTER TABLE Promotion ADD CONSTRAINT Promotion_PromotionStatus
    FOREIGN KEY (StatusID)
    REFERENCES PromotionStatus (PromotionStatusID);

-- Reference: Promotion_PromotionTarget (table: Promotion)
ALTER TABLE Promotion ADD CONSTRAINT Promotion_PromotionTarget
    FOREIGN KEY (PromotionTargetID)
    REFERENCES PromotionTarget (PromotionTargetID);

-- Reference: Promotion_PromotionType (table: Promotion)
ALTER TABLE Promotion ADD CONSTRAINT Promotion_PromotionType
    FOREIGN KEY (PromotionTypeID)
    REFERENCES PromotionType (PromotionTypeID);

-- Reference: RestaurantBooking_Customer (table: RestaurantBooking)
ALTER TABLE RestaurantBooking ADD CONSTRAINT RestaurantBooking_Customer
    FOREIGN KEY (CustomerID)
    REFERENCES Customer (CustomerID);

-- Reference: RestaurantBooking_RestaurantTable (table: RestaurantBooking)
ALTER TABLE RestaurantBooking ADD CONSTRAINT RestaurantBooking_RestaurantTable
    FOREIGN KEY (TableID)
    REFERENCES RestaurantTable (TableID);

-- Reference: RoomBook_Account (table: RoomBooking)
ALTER TABLE RoomBooking ADD CONSTRAINT RoomBook_Account
    FOREIGN KEY (AccountID)
    REFERENCES Account (AccountID);

-- Reference: RoomBook_Customer (table: RoomBooking)
ALTER TABLE RoomBooking ADD CONSTRAINT RoomBook_Customer
    FOREIGN KEY (CustomerID)
    REFERENCES Customer (CustomerID);

-- Reference: RoomBook_HotelRoom (table: RoomBooking)
ALTER TABLE RoomBooking ADD CONSTRAINT RoomBook_HotelRoom
    FOREIGN KEY (RoomID)
    REFERENCES HotelRoom (RoomID);

-- Reference: RoomBooking_BookingStatus (table: RoomBooking)
ALTER TABLE RoomBooking ADD CONSTRAINT RoomBooking_BookingStatus
    FOREIGN KEY (BookingStatusID)
    REFERENCES BookingStatus (BookingStatusID);

-- Reference: RoomFacilities_Facility (table: RoomFacility)
ALTER TABLE RoomFacility ADD CONSTRAINT RoomFacilities_Facility
    FOREIGN KEY (FacilityID)
    REFERENCES Facility (FacilityID);

-- Reference: RoomFacilities_HotelRoom (table: RoomFacility)
ALTER TABLE RoomFacility ADD CONSTRAINT RoomFacilities_HotelRoom
    FOREIGN KEY (RoomID)
    REFERENCES HotelRoom (RoomID);

-- init data
-- Table Role
INSERT INTO Role (RoleName, Salary)
VALUES
('Admin', 5000),
('Hotel Manager', 3500),
('Receptionist', 2000),
('Maintenance Staff', 1500),
('Marketer', 1750);

-- Table FacilityMaintenanceStatus
INSERT INTO FacilityMaintenanceStatus (StatusName)
VALUES
('Opening'),
('Processing'),
('Done'),
('Canceled');

-- Table BookingStatus
INSERT INTO BookingStatus (BookingStatusName)
VALUES
('Booked'),
('Checked In'),
('Checked Out'),
('Canceled');

-- Table PromotionType
INSERT INTO PromotionType (TypeName)
VALUES
('Discount By Percent'),
('Discount By Money');

-- Table PromotionTarget
INSERT INTO PromotionTarget(TargetName)
VALUES
('Room'),
('Loyal Customer'),
('All Customer');

-- Table PromotionStatus
INSERT INTO PromotionStatus(StatusName)
VALUES
('Waiting for approval'),
('Approved'),
('Rejected'),
('Canceled');
-- End of file.

