IF EXISTS (SELECT *FROM SYSDATABASES WHERE NAME ='GOATBOOKING' )
		DROP DATABASE GOATBOOKING 


CREATE DATABASE GOATBOOKING

GO

USE GOATBOOKING
GO

CREATE TABLE Users(
	user_id BIGINT  NOT NULL,
	user_name VARCHAR(255) NOT NULL,
	password VARCHAR(255) NOT NULL,
	email VARCHAR(255) NOT NULL,
	phone_number VARCHAR(255) NOT NULL,
	gender INT,
	full_name VARCHAR(255) NOT NULL,
	avatar VARCHAR(255),
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	role INT NOT NULL,
	CONSTRAINT pk_Users PRIMARY KEY(user_id)
);



CREATE TABLE Bookings(
	booking_id BIGINT  NOT NULL,
	check_in_date BIGINT NOT NULL,
	check_out_date BIGINT NOT NULL,
	deposit_price DECIMAL(10,2),
	total_price DECIMAL(10,2),
	status INT,
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	user_id BIGINT,
	CONSTRAINT pk_Bookings PRIMARY KEY(booking_id),
	CONSTRAINT fk_Users FOREIGN KEY(user_id) REFERENCES Users(user_id)
);

-- Bảng Homestays
CREATE TABLE Homestays(
	homestay_id BIGINT  NOT NULL,
	name VARCHAR(255) NOT NULL,
	description TEXT,
	ward VARCHAR(255),
	district VARCHAR(255),
	province VARCHAR(255),
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	user_id BIGINT,
	CONSTRAINT pk_Homestays PRIMARY KEY(homestay_id),
	CONSTRAINT fk_Users_Homestays FOREIGN KEY(user_id) REFERENCES Users(user_id)
);

-- Bảng Rooms
CREATE TABLE Rooms(
	room_id BIGINT  NOT NULL,
	room_name VARCHAR(255) NOT NULL,
	room_type INT NOT NULL,
	price DECIMAL(10,2),
	status INT,
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	homestay_id BIGINT NOT NULL,
	booking_id BIGINT NOT NULL,
	CONSTRAINT pk_Rooms PRIMARY KEY(room_id),
	CONSTRAINT fk_Rooms_Homestays FOREIGN KEY(homestay_id) REFERENCES Homestays(homestay_id),
	CONSTRAINT fk_Rooms_Bookings FOREIGN KEY(booking_id) REFERENCES Bookings(booking_id)
);

-- Bảng Reviews
CREATE TABLE Reviews(
	review_id BIGINT  NOT NULL,
	rate INT,
	comment TEXT,
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	homestay_id BIGINT NOT NULL,
	user_id BIGINT NOT NULL,
	CONSTRAINT pk_Reviews PRIMARY KEY(review_id),
	CONSTRAINT fk_Reviews_Homestays FOREIGN KEY(homestay_id) REFERENCES Homestays(homestay_id),
	CONSTRAINT fk_Reviews_Users FOREIGN KEY(user_id) REFERENCES Users(user_id)
);

-- Bảng Photos
CREATE TABLE Photos(
	photo_id BIGINT  NOT NULL,
	name_photo VARCHAR(255),
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	homestay_id BIGINT NOT NULL,
	CONSTRAINT pk_Photos PRIMARY KEY(photo_id),
	CONSTRAINT fk_Photos_Homestays FOREIGN KEY(homestay_id) REFERENCES Homestays(homestay_id)
);

-- Bảng Services
CREATE TABLE Services(
	service_id BIGINT  NOT NULL,
	service_name VARCHAR(255),
	description TEXT,
	price DECIMAL(10,2),
	created_at BIGINT NOT NULL,
	updated_at BIGINT NOT NULL,
	CONSTRAINT pk_Services PRIMARY KEY(service_id)
);

-- Bảng Services_advantage
CREATE TABLE Services_advantage(
	homestay_id BIGINT NOT NULL,
	service_id BIGINT NOT NULL,
	description VARCHAR(255) NOT NULL,
	CONSTRAINT pk_Services_advantage PRIMARY KEY(homestay_id, service_id),
	CONSTRAINT fk_Services_advantage_Homestays FOREIGN KEY(homestay_id) REFERENCES Homestays(homestay_id),
	CONSTRAINT fk_Services_advantage_Services FOREIGN KEY(service_id) REFERENCES Services(service_id)
);

INSERT INTO Users (user_id, user_name, password, email, phone_number, gender, full_name, avatar, created_at, updated_at, role)
VALUES 
    (1, 'john_doe', 'password123', 'john.doe@example.com', '1234567890', 1, 'John Doe', 'avatar1.png', 20241001, 20241001, 1),
    (2, 'jane_smith', 'mypassword', 'jane.smith@example.com', '0987654321', 0, 'Jane Smith', 'avatar2.png', 20241002, 20241002, 2),
    (3, 'alice_nguyen', 'alicepass', 'alice.nguyen@example.com', '1122334455', 1, 'Alice Nguyen', 'avatar3.png', 20241003, 20241003, 1),
    (4, 'bob_lee', 'bobsecure', 'bob.lee@example.com', '4433221100', 1, 'Bob Lee', 'avatar4.png', 20241004, 20241004, 2),
    (5, 'sara_connor', 'sarapass', 'sara.connor@example.com', '5544332211', 0, 'Sara Connor', 'avatar5.png', 20241005, 20241005, 1);

INSERT INTO Bookings (booking_id, check_in_date, check_out_date, deposit_price, total_price, status, created_at, updated_at, user_id)
VALUES 
    (1, 20241010, 20241015, 200.00, 1000.00, 1, 20241001, 20241001, 1),
    (2, 20241012, 20241016, 150.00, 800.00, 1, 20241002, 20241002, 2),
    (3, 20241014, 20241018, 100.00, 600.00, 0, 20241003, 20241003, 3),
    (4, 20241016, 20241020, 250.00, 1200.00, 1, 20241004, 20241004, 4),
    (5, 20241018, 20241022, 180.00, 900.00, 0, 20241005, 20241005, 5);


INSERT INTO Homestays (homestay_id, name, description, ward, district, province, created_at, updated_at, user_id)
VALUES 
    (1, 'Homestay Hanoi Central', 'A cozy homestay located in the heart of Hanoi', 'Phuong 7', 'Quan Ba Dinh', 'Ha Noi', 20241001, 20241001, 1),
    (2, 'Saigon Riverside Homestay', 'Beautiful homestay with a view of Saigon River', 'Phuong Binh Thanh', 'Quan 1', 'Ho Chi Minh', 20241002, 20241002, 2),
    (3, 'Homestay Da Nang Beach', 'Relaxing homestay just minutes from the beach', 'Phuong Ngu Hanh Son', 'Quan Ngu Hanh Son', 'Da Nang', 20241003, 20241003, 3),
    (4, 'Ninh Binh Nature Homestay', 'Experience nature and stunning views in Ninh Binh', 'Phuong Tam Coc', 'Huyen Hoa Lu', 'Ninh Binh', 20241004, 20241004, 1),
    (5, 'Sapa Mountain Homestay', 'Beautiful homestay in the mountains of Sapa', 'Phuong Sa Pa', 'Huyen Sa Pa', 'Lao Cai', 20241005, 20241005, 2);
INSERT INTO Rooms (room_id, room_name, room_type, price, status, created_at, updated_at, homestay_id, booking_id)
VALUES 
    (1, 'Deluxe Room', 1, 150.00, 1, 20241015, 20241015, 1, 1),
    (2, 'Standard Room', 2, 100.00, 1, 20241015, 20241015, 1, 2),
    (3, 'Family Room', 1, 200.00, 0, 20241017, 20241017, 2, 3),
    (4, 'Single Room', 2, 80.00, 1, 20241018, 20241018, 3, 4),
    (5, 'Superior Suite', 3, 300.00, 1, 20241019, 20241019, 4, 5);
INSERT INTO Reviews (review_id, rate, comment, created_at, updated_at, homestay_id, user_id)
VALUES 
    (1, 5, 'Wonderful stay! The place was beautiful and very clean.', 20241015, 20241015, 1, 1),
    (2, 4, 'Very nice location, but the room could be bigger.', 20241016, 20241016, 1, 2),
    (3, 3, 'Average experience. The service was okay, but not great.', 20241017, 20241017, 2, 3),
    (4, 5, 'Loved it! Perfect for families, very spacious and clean.', 20241018, 20241018, 3, 4),
    (5, 2, 'Not as expected. The photos were misleading.', 20241019, 20241019, 4, 5);
INSERT INTO Photos (photo_id, name_photo, created_at, updated_at, homestay_id)
VALUES 
    (1, 'Cozy Cottage Living Room', 20241015, 20241015, 1),
    (2, 'Beachside Bungalow View', 20241016, 20241016, 2),
    (3, 'Mountain Retreat Exterior', 20241017, 20241017, 3),
    (4, 'Luxurious Suite with Ocean View', 20241018, 20241018, 4),
    (5, 'Charming Garden Area', 20241019, 20241019, 5);
INSERT INTO Services (service_id, service_name, description, price, created_at, updated_at)
VALUES 
    (1, 'Free WiFi', 'High-speed internet available throughout the homestay.', 0.00, 20241001, 20241001),
    (2, 'Airport Pickup', 'Convenient airport pickup service.', 30.00, 20241002, 20241002),
    (3, 'Breakfast Included', 'Delicious breakfast served every morning.', 10.00, 20241003, 20241003),
    (4, 'Guided Tours', 'Explore the local area with our guided tours.', 50.00, 20241004, 20241004),
    (5, 'Spa Access', 'Relax and enjoy our on-site spa services.', 100.00, 20241005, 20241005);
INSERT INTO Services_advantage (homestay_id, service_id, description)
VALUES 
    (1, 1, 'Enjoy complimentary high-speed WiFi in all areas.'),
    (1, 3, 'Breakfast included in your stay.'),
    (2, 2, 'Airport pickup available upon request.'),
    (2, 4, 'Guided tours can be arranged for your convenience.'),
    (3, 1, 'Free WiFi available for all guests.');

-- Thêm dữ liệu vào bảng Users
INSERT INTO Users (user_id, user_name, password, email, phone_number, gender, full_name, avatar, created_at, updated_at, role)
VALUES (0, '', '', '', '', 1, '', '', '', '', '');
INSERT INTO Bookings (booking_id, check_in_date, check_out_date, deposit_price, total_price, status, created_at, updated_at, user_id)
VALUES (0, 0, 0, 0.00, 0.00, 0, 0, 0, 0);

INSERT INTO Users (user_id, user_name, password, email, phone_number, gender, full_name, avatar, created_at, updated_at, role)
VALUES 
    (6, 'michael_brown', 'passmike', 'michael.brown@example.com', '1234561111', 1, 'Michael Brown', 'avatar6.png', 20241006, 20241006, 1),
    (7, 'lisa_white', 'lisapass', 'lisa.white@example.com', '6543212222', 0, 'Lisa White', 'avatar7.png', 20241007, 20241007, 2),
    (8, 'charles_tan', 'charlessecure', 'charles.tan@example.com', '5556667777', 1, 'Charles Tan', 'avatar8.png', 20241008, 20241008, 1),
    (9, 'nancy_lee', 'nancy123', 'nancy.lee@example.com', '1112223333', 0, 'Nancy Lee', 'avatar9.png', 20241009, 20241009, 2),
    (10, 'george_miller', 'georgepass', 'george.miller@example.com', '9998887777', 1, 'George Miller', 'avatar10.png', 20241010, 20241010, 1),
    (11, 'emma_davis', 'emmapass', 'emma.davis@example.com', '3332221111', 0, 'Emma Davis', 'avatar11.png', 20241011, 20241011, 2),
    (12, 'jack_wilson', 'jacksecure', 'jack.wilson@example.com', '6665554444', 1, 'Jack Wilson', 'avatar12.png', 20241012, 20241012, 1),
    (13, 'anna_thompson', 'annapass', 'anna.thompson@example.com', '7776665555', 0, 'Anna Thompson', 'avatar13.png', 20241013, 20241013, 2),
    (14, 'robert_clark', 'robertsecure', 'robert.clark@example.com', '8887776666', 1, 'Robert Clark', 'avatar14.png', 20241014, 20241014, 1),
    (15, 'sophia_moore', 'sophiapass', 'sophia.moore@example.com', '4443332222', 0, 'Sophia Moore', 'avatar15.png', 20241015, 20241015, 2);

-- Thêm dữ liệu vào bảng Bookings
INSERT INTO Bookings (booking_id, check_in_date, check_out_date, deposit_price, total_price, status, created_at, updated_at, user_id)
VALUES 
    (6, 20241020, 20241025, 220.00, 1100.00, 1, 20241006, 20241006, 6),
    (7, 20241021, 20241026, 180.00, 900.00, 1, 20241007, 20241007, 7),
    (8, 20241022, 20241027, 150.00, 750.00, 0, 20241008, 20241008, 8),
    (9, 20241023, 20241028, 240.00, 1200.00, 1, 20241009, 20241009, 9),
    (10, 20241024, 20241029, 200.00, 1000.00, 1, 20241010, 20241010, 10),
    (11, 20241025, 20241030, 210.00, 1050.00, 1, 20241011, 20241011, 11),
    (12, 20241026, 20241031, 170.00, 850.00, 0, 20241012, 20241012, 12),
    (13, 20241027, 20241101, 190.00, 950.00, 1, 20241013, 20241013, 13),
    (14, 20241028, 20241102, 230.00, 1150.00, 0, 20241014, 20241014, 14),
    (15, 20241029, 20241103, 250.00, 1250.00, 1, 20241015, 20241015, 15);

-- Thêm dữ liệu vào bảng Homestays
INSERT INTO Homestays (homestay_id, name, description, ward, district, province, created_at, updated_at, user_id)
VALUES 
    (6, 'Hue Imperial Homestay', 'Elegant homestay near the ancient city', 'Phuong 5', 'Quan Thanh Pho', 'Hue', 20241006, 20241006, 6),
    (7, 'Hoi An Riverside Homestay', 'Charming homestay by the river', 'Phuong 2', 'Quan Hoi An', 'Quang Nam', 20241007, 20241007, 7),
    (8, 'Phu Quoc Paradise Homestay', 'Tropical retreat with beach access', 'Phuong 3', 'Quan Phu Quoc', 'Kien Giang', 20241008, 20241008, 8),
    (9, 'Can Tho Eco Homestay', 'Eco-friendly homestay in the Mekong Delta', 'Phuong 4', 'Quan Ninh Kieu', 'Can Tho', 20241009, 20241009, 9),
    (10, 'Da Lat Flower Homestay', 'Beautiful homestay surrounded by flowers', 'Phuong 6', 'Quan Da Lat', 'Lam Dong', 20241010, 20241010, 10),
    (11, 'Ha Giang Loop Homestay', 'Homestay with scenic mountain views', 'Phuong 7', 'Huyen Dong Van', 'Ha Giang', 20241011, 20241011, 11),
    (12, 'Vung Tau Coastal Homestay', 'Relaxing homestay with sea views', 'Phuong 8', 'Quan Vung Tau', 'Ba Ria - Vung Tau', 20241012, 20241012, 12),
    (13, 'Con Dao Hideaway Homestay', 'Isolated retreat on Con Dao Island', 'Phuong 9', 'Quan Con Dao', 'Ba Ria - Vung Tau', 20241013, 20241013, 13),
    (14, 'Bac Ninh Heritage Homestay', 'Traditional homestay near pagodas', 'Phuong 10', 'Quan Bac Ninh', 'Bac Ninh', 20241014, 20241014, 14),
    (15, 'Sa Dec Garden Homestay', 'Homestay with beautiful garden views', 'Phuong 11', 'Huyen Sa Dec', 'Dong Thap', 20241015, 20241015, 15);

-- Thêm dữ liệu vào bảng Rooms
INSERT INTO Rooms (room_id, room_name, room_type, price, status, created_at, updated_at, homestay_id, booking_id)
VALUES 
    (6, 'Garden Room', 1, 140.00, 1, 20241020, 20241020, 6, 6),
    (7, 'Twin Room', 2, 120.00, 1, 20241021, 20241021, 7, 7),
    (8, 'King Room', 1, 180.00, 1, 20241022, 20241022, 8, 8),
    (9, 'Double Room', 2, 110.00, 1, 20241023, 20241023, 9, 9),
    (10, 'Executive Suite', 3, 250.00, 1, 20241024, 20241024, 10, 10),
    (11, 'Budget Room', 2, 90.00, 0, 20241025, 20241025, 11, 11),
    (12, 'Studio Room', 1, 160.00, 1, 20241026, 20241026, 12, 12),
    (13, 'Suite Room', 3, 280.00, 1, 20241027, 20241027, 13, 13),
    (14, 'Panorama Room', 1, 200.00, 0, 20241028, 20241028, 14, 14),
    (15, 'Penthouse Suite', 3, 350.00, 1, 20241029, 20241029, 15, 15);

-- Thêm dữ liệu vào bảng Reviews
INSERT INTO Reviews (review_id, rate, comment, created_at, updated_at, homestay_id, user_id)
VALUES 
    (6, 5, 'Amazing stay with lovely hosts!', 20241020, 20241020, 6, 6),
    (7, 4, 'Great location but slightly overpriced.', 20241021, 20241021, 7, 7),
    (8, 3, 'Decent experience but could be cleaner.', 20241022, 20241022, 8, 8),
    (9, 4, 'Nice homestay with friendly staff.', 20241023, 20241023, 9, 9),
    (10, 5, 'Exceptional view and service!', 20241024, 20241024, 10, 10),
    (11, 2, 'Room didn’t match the photos.', 20241025, 20241025, 11, 11),
    (12, 3, 'Comfortable but could be better.', 20241026, 20241026, 12, 12),
    (13, 4, 'Good value for the price.', 20241027, 20241027, 13, 13),
    (14, 1, 'Not as expected, too noisy.', 20241028, 20241028, 14, 14),
    (15, 5, 'Perfect place for a getaway!', 20241029, 20241029, 15, 15);

-- Thêm dữ liệu vào bảng Photos
INSERT INTO Photos (photo_id, name_photo, created_at, updated_at, homestay_id)
VALUES 
    (6, 'Hue Homestay Interior', 20241020, 20241020, 6),
    (7, 'Riverside Balcony', 20241021, 20241021, 7),
    (8, 'Beachfront Bungalow', 20241022, 20241022, 8),
    (9, 'Mekong Delta View', 20241023, 20241023, 9),
    (10, 'Garden Area', 20241024, 20241024, 10),
    (11, 'Mountain Scenery', 20241025, 20241025, 11),
    (12, 'Ocean Suite', 20241026, 20241026, 12),
    (13, 'Island Retreat', 20241027, 20241027, 13),
    (14, 'Heritage House', 20241028, 20241028, 14),
    (15, 'Garden Pathway', 20241029, 20241029, 15);

-- Thêm dữ liệu vào bảng Services
INSERT INTO Services (service_id, service_name, description, price, created_at, updated_at)
VALUES 
    (6, 'Laundry Service', 'Convenient laundry services available.', 15.00, 20241006, 20241006),
    (7, 'Room Service', 'Order food and drinks to your room.', 20.00, 20241007, 20241007),
    (8, 'Yoga Class', 'Morning yoga classes offered.', 25.00, 20241008, 20241008),
    (9, 'BBQ Facility', 'Access to outdoor BBQ area.', 30.00, 20241009, 20241009),
    (10, 'Bike Rental', 'Rent bikes for local sightseeing.', 10.00, 20241010, 20241010),
    (11, 'Kids Club', 'Activities and fun for children.', 40.00, 20241011, 20241011),
    (12, 'Airport Drop-off', 'Convenient airport drop-off service.', 35.00, 20241012, 20241012),
    (13, 'Cooking Class', 'Learn to cook local dishes.', 50.00, 20241013, 20241013),
    (14, 'Car Rental', 'Rent a car for your stay.', 60.00, 20241014, 20241014),
    (15, 'Massage Therapy', 'Relaxing massage therapy.', 80.00, 20241015, 20241015);

-- Thêm dữ liệu vào bảng Services_advantage
INSERT INTO Services_advantage (homestay_id, service_id, description)
VALUES 
    (6, 1, 'High-speed internet in all rooms.'),
    (7, 2, 'Free airport pickup for all guests.'),
    (8, 3, 'Daily breakfast included.'),
    (9, 4, 'Guided tours to local attractions.'),
    (10, 5, 'Spa and wellness services available.'),
    (11, 6, 'Laundry service on request.'),
    (12, 7, 'Room service from 7 AM to 10 PM.'),
    (13, 8, 'Yoga classes available in the mornings.'),
    (14, 9, 'BBQ area available for guests.'),
    (15, 10, 'Bike rental for easy exploration.');



-- Hiển thị dữ liệu từ bảng Users
SELECT * FROM Users;

-- Hiển thị dữ liệu từ bảng Bookings
SELECT * FROM Bookings;

-- Hiển thị dữ liệu từ bảng Homestays
SELECT * FROM Homestays;

-- Hiển thị dữ liệu từ bảng Rooms
SELECT * FROM Rooms;

-- Hiển thị dữ liệu từ bảng Reviews
SELECT * FROM Reviews;

-- Hiển thị dữ liệu từ bảng Photos
SELECT * FROM Photos;

-- Hiển thị dữ liệu từ bảng Services
SELECT * FROM Services;

-- Hiển thị dữ liệu từ bảng Services_advantage
SELECT * FROM Services_advantage;
