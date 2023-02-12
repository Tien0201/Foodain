USE QLBH
GO

Select * from LoaiMH
INSERT INTO LoaiMH VALUES(N'Gà')
INSERT INTO LoaiMH VALUES(N'Nước')
INSERT INTO LoaiMH VALUES(N'Hamburger')
INSERT INTO LoaiMH VALUES(N'Khoai')
INSERT INTO LoaiMH VALUES(N'Khác')
INSERT INTO LoaiMH VALUES(N'Combo')

Select * from MatHang
INSERT INTO MatHang VALUES('171000', N'Couple Set 1', N'02 Gà chiên \n 01 Hamburger \n 01 Khoai tây chiên \n 02 Pepsi (M)', '/Content/Images/Food/couple set 1.png', NULL, NULL, NULL, NULL, 'XL', '50', '6', NULL)
INSERT INTO MatHang VALUES('99000', N'Combo Burger Double Double', N'1 Burger Double Double \n 1 Khoai tây chiên (M) \n 01 Khoai tây chiên \n 1 Pepsi (M)', '/Content/Images/Food/comboDOUBLEthit.png', NULL, NULL, NULL, NULL, 'XL', '70', '6', NULL)
INSERT INTO MatHang VALUES('79000', N'Combo Burger Tôm', N'1 Burger Tôm \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/comboburgerTOM.png', NULL, NULL, NULL, NULL, 'XL', '80', '6', NULL)
INSERT INTO MatHang VALUES('69000', N'Combo Burger Phô Mai', N'1 Burger Phô Mai \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/comboBURGERPHOMAI.png', NULL, NULL, NULL, NULL, 'XL', '80', '6', NULL)
INSERT INTO MatHang VALUES('76000', N'Combo Burger Gà Thượng Hạng', N'1 Burger Gà Thượng Hạng \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/comboburgerGATHUONGHANG.png', NULL, NULL, NULL, NULL, 'XL', '80', '6', NULL)
INSERT INTO MatHang VALUES('106000', N'Combo Burger Mozzarella', N'1 Burger Mozzarella \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/combo_mozzarella.png', NULL, NULL, NULL, NULL, 'XL', '50', '6', NULL)
INSERT INTO MatHang VALUES('77000', N'Combo Burger Bulgogi', N'1 Burger Bulgogi \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/combo_bulgogi_4.png', NULL, NULL, NULL, NULL, 'XL', '80', '6', NULL)
INSERT INTO MatHang VALUES('69000', N'Combo Burger Bò Teriyaki', N'1 Burger Bò Teriyaki \n 1 Khoai tây chiên (M) \n 1 Pepsi (M)', '/Content/Images/Food/combo_beef-teriyaki.png', NULL, NULL, NULL, NULL, 'XL', '80', '6', NULL)

INSERT INTO MatHang VALUES('39000', N'Gà Tuyết Vàng', N'1 miếng', '/Content/Images/Food/Gatuyetvang(1mieng).png', NULL, NULL, NULL, NULL, 'XL', '40', '1', NULL)
INSERT INTO MatHang VALUES('115000', N'Gà Tuyết Vàng', N'3 miếng', '/Content/Images/Food/Gatuyetvang(3mieng).png', NULL, NULL, NULL, NULL, 'XL', '30', '1', NULL)
INSERT INTO MatHang VALUES('35000', N'Gà Rán', N'1 miếng', '/Content/Images/Food/garan(1mieng).png', NULL, NULL, NULL, NULL, 'XL', '35', '1', NULL)
INSERT INTO MatHang VALUES('101000', N'Gà Rán', N'3 miếng', '/Content/Images/Food/garan(3mieng).png', NULL, NULL, NULL, NULL, 'XL', '30', '1', NULL)
INSERT INTO MatHang VALUES('40000', N'Gà Sốt HS', N'1 miếng', '/Content/Images/Food/gasotHS(1mieng).png', NULL, NULL, NULL, NULL, 'XL', '50', '1', NULL)
INSERT INTO MatHang VALUES('112000', N'Gà Sốt HS', N'3 miếng', '/Content/Images/Food/gasotHS(3mieng).png', NULL, NULL, NULL, NULL, 'XL', '40', '1', NULL)
INSERT INTO MatHang VALUES('40000', N'Gà Sốt Đậu', N'1 miếng', '/Content/Images/Food/gasotdau(1mieng).png', NULL, NULL, NULL, NULL, 'XL', '50', '1', NULL)
INSERT INTO MatHang VALUES('112000', N'Gà Sốt Đậu', N'3 miếng', '/Content/Images/Food/gasotdau(3mieng).png', NULL, NULL, NULL, NULL, 'XL', '36', '1', NULL)
INSERT INTO MatHang VALUES('40000', N'Gà Sốt Pho Mai', N'1 miếng', '/Content/Images/Food/gasotphomai(1mieng).png', NULL, NULL, NULL, NULL, 'XL', '60', '1', NULL)
INSERT INTO MatHang VALUES('112000', N'Gà Sốt Pho Mai', N'3 miếng', '/Content/Images/Food/gasotphomai(3mieng).png', NULL, NULL, NULL, NULL, 'XL', '40', '1', NULL)

INSERT INTO MatHang VALUES('18000', N'Pepsi', N'L', '/Content/Images/Food/nuocPEPSI(L).png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)
INSERT INTO MatHang VALUES('28000', N'Pepsi', N'M', '/Content/Images/Food/nuocPEPSI(L).png', NULL, NULL, NULL, NULL, 'M', '200', '2', NULL)
INSERT INTO MatHang VALUES('18000', N'Mirinda', N'L', '/Content/Images/Food/nuocMIRINDA(L).png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)
INSERT INTO MatHang VALUES('28000', N'Mirinda', N'M', '/Content/Images/Food/nuocMIRINDA(L).png', NULL, NULL, NULL, NULL, 'M', '200', '2', NULL)
INSERT INTO MatHang VALUES('27000', N'Nước Cam', N'L', '/Content/Images/Food/nuocCAM.png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)
INSERT INTO MatHang VALUES('18000', N'7 UP', N'L', '/Content/Images/Food/Nuoc7UP(L).png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)
INSERT INTO MatHang VALUES('28000', N'7 UP', N'M', '/Content/Images/Food/Nuoc7UP(L).png', NULL, NULL, NULL, NULL, 'M', '200', '2', NULL)
INSERT INTO MatHang VALUES('25000', N'nuoc7UPDUADUA', N'L', '/Content/Images/Food/nuoc7UPDUADUA.png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)
INSERT INTO MatHang VALUES('25000', N'nuoc7UPDUALUADAO', N'L', '/Content/Images/Food/nuoc7UPDUALUADAO.png', NULL, NULL, NULL, NULL, 'L', '200', '2', NULL)

INSERT INTO MatHang VALUES('48000', N'Burger Tôm', N'', '/Content/Images/Food/burgerTOM.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('43000', N'Burger Phô Mai', N'', '/Content/Images/Food/burgerPHOMAI.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('48000', N'Burger Gà Thượng Hạng', N'', '/Content/Images/Food/burgerGATHUONGHANG.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('40000', N'Burger Cá', N'', '/Content/Images/Food/burgerCA.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('85000', N'Burger Mozzarella', N'', '/Content/Images/Food/burger_mozzarella-burger.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('70000', N'Burger Double Double', N'', '/Content/Images/Food/burger_ddouble-burger.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('46000', N'Burger Bulgogi', N'', '/Content/Images/Food/burger_bulgogi-burger.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)
INSERT INTO MatHang VALUES('43000', N'Burger Bò Teriyaki', N'', '/Content/Images/Food/burger_beef-teriyaki-burger.png', NULL, NULL, NULL, NULL, 'L', '150', '3', NULL)

INSERT INTO MatHang VALUES('39000', N'Khoai Tây Lắc', N'L', '/Content/Images/Food/khoaitaylac.png', NULL, NULL, NULL, NULL, 'L', '200', '4', NULL)
INSERT INTO MatHang VALUES('29000', N'Khoai Tây Chiên', N'M', '/Content/Images/Food/khoaitaichien(M).png', NULL, NULL, NULL, NULL, 'L', '200', '4', NULL)

INSERT INTO MatHang VALUES('35000', N'Phô Mai Que', N'L', '/Content/Images/Food/phomaique.png', NULL, NULL, NULL, NULL, 'L', '200', '5', NULL)
INSERT INTO MatHang VALUES('31000', N'Gà Xiên Que', N'1 que', '/Content/Images/Food/gaxienque.png', NULL, NULL, NULL, NULL, 'M', '100', '4', NULL)
INSERT INTO MatHang VALUES('50000', N'Phô Mai Que', N'2 que', '/Content/Images/Food/gaxienque(2que).png', NULL, NULL, NULL, NULL, 'L', '100', '5', NULL)
INSERT INTO MatHang VALUES('20000', N'Bánh Táo', N'L', '/Content/Images/Food/banhtao.png', NULL, NULL, NULL, NULL, 'L', '70', '5', NULL)
INSERT INTO MatHang VALUES('28000', N'Mực Rán', N'3 miếng', '/Content/Images/Food/mucran(3mieng).png', NULL, NULL, NULL, NULL, 'M', '100', '5', NULL)
INSERT INTO MatHang VALUES('28000', N'Mực Rán', N'3 miếng', '/Content/Images/Food/mucran(3mieng).png', NULL, NULL, NULL, NULL, 'L', '200', '5', NULL)
INSERT INTO MatHang VALUES('43000', N'Gà Lăc', N'M', '/Content/Images/Food/galac.png', NULL, NULL, NULL, NULL, 'M', '200', '5', NULL)




Select * from KhuyenMai
INSERT INTO KhuyenMai VALUES('10', 'phantram')
INSERT INTO KhuyenMai VALUES('20', 'phantram')
INSERT INTO KhuyenMai VALUES('25', 'phantram')
INSERT INTO KhuyenMai VALUES('30', 'phantram')
INSERT INTO KhuyenMai VALUES('50', 'phantram')
INSERT INTO KhuyenMai VALUES('10000', 'nghin')
INSERT INTO KhuyenMai VALUES('20000', 'nghin')
INSERT INTO KhuyenMai VALUES('30000', 'nghin')

Select * from Voucher
INSERT INTO Voucher VALUES('FDAWelcome', 'Nhan Dip Khai Truong', '10000', 'tructiep', 'Y')
INSERT INTO Voucher VALUES('WelcomeNewUser', 'Chao mung nguoi dung moi', '15000', 'tructiep', 'Y')
INSERT INTO Voucher VALUES('FDAEvent', 'Event 1', '10', 'phantram', 'Y')
INSERT INTO Voucher VALUES('FDAWinter', 'Event mua dong', '9000', 'tructiep', 'Y')

Select * from PhuongThucThanhToan
INSERT INTO PhuongThucThanhToan VALUES(N'Thanh toán trực tiếp')
INSERT INTO PhuongThucThanhToan VALUES(N'COD')

Select * from Account
INSERT INTO Account VALUES('SangNee', '123456', 'Pham Cao Sang', '330 Bac Hai', 'kt_windy09@yahoo.com', '0582754857', 'User')