CREATE DATABASE FitnessGym;

-- Используем созданную базу данных
USE FitnessGym;

-- Таблица пользователей (менеджеры и администраторы)
CREATE TABLE Users (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    FullName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(20) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    [Role] varchar(20) NOT NULL,
	Username varchar(50) not null,
	passcode int not null,
	profilePics nvarchar(MAX) not null
);

-- Вставка данных в таблицу пользователей
INSERT INTO Users (ID, FullName, Email, PhoneNumber, Salary,[Role], Username, passcode, profilePics) 
VALUES 
(NEWID(),'Румянцев Кирилл Алексеевич', 'rumyancev@example.com', '+79001234567', 50000, 'Администратор', 'Bloodysharp', '12345', 'C:\Users\Пользователь\Desktop\1.jpg'),
(NEWID(),'Тельных Тимофей Константинович', 'telnih@example.com', '+79007654321', 45000, 'Менеджер', 'NotAki', '12345','C:\Users\Пользователь\Desktop\2.jpg'),
(NEWID(),'Сидоров Александр Михайлович', 'sidorov@example.com', '+79003456789', 55000, 'Менеджер', 'Admin', '54321','C:\Users\Пользователь\Desktop\1.jpg'),
(NEWID(),'Васильев Олег Юрьевич', 'vasilyev@example.com', '+79009876543', 48000, 'Менеджер', 'vasil', '12345','C:\Users\Пользователь\Desktop\2.jpg');

-- Таблица тренеров
CREATE TABLE Trainers (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    FullName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(20) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    ExperienceYears INT NOT NULL,
    Specialty VARCHAR(255) NOT NULL
);

-- Вставка данных в таблицу тренеров
INSERT INTO Trainers (ID, FullName, Email, PhoneNumber, Salary, ExperienceYears, Specialty)
VALUES
(NEWID(),'Кузнецов Дмитрий Викторович', 'kuznetsov@example.com', '+79005554433', 70000, 5, 'Персональные тренировки'),
(NEWID(),'Федорова Мария Ивановна', 'fedorova@example.com', '+79001231234', 65000, 4, 'Йога'),
(NEWID(),'Волков Олег Андреевич', 'volkov@example.com', '+79007778899', 75000, 6, 'Силовые тренировки'),
(NEWID(),'Смирнова Елена Александровна', 'smirnova@example.com', '+79006543210', 60000, 3, 'Пилатес'),
(NEWID(),'Романов Сергей Викторович', 'romanov@example.com', '+79004567891', 72000, 5, 'Кроссфит'),
(NEWID(),'Ильина Ольга Николаевна', 'ilina@example.com', '+79002345678', 68000, 4, 'Кардиотренировки'),
(NEWID(),'Григорьев Максим Олегович', 'grigoriev@example.com', '+79001239876', 71000, 5, 'Боевые искусства'),
(NEWID(),'Ковалев Артем Сергеевич', 'kovalev@example.com', '+79003450987', 67000, 3, 'Растяжка'),
(NEWID(),'Евдокимова Анастасия Владимировна', 'evdokimova@example.com', '+79007654987', 69000, 4, 'Аэробика'),
(NEWID(),'Захаров Павел Андреевич', 'zaharov@example.com', '+79006789012', 73000, 6, 'Силовые тренировки');

-- Таблица посетителей
CREATE TABLE Visitors (
    ID UNIQUEIDENTIFIER  PRIMARY KEY,
    FullName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(20) NOT NULL,
    SubscriptionType varchar(40) NOT NULL,
    SubscriptionStatus varchar(50) NOT NULL,
    SubscriptionStart DATE NOT NULL,
    SubscriptionEnd DATE NOT NULL,
    SubscriptionPrice DECIMAL(10, 2) NOT NULL
);

-- Вставка данных в таблицу посетителей
INSERT INTO Visitors (ID,FullName, Email, PhoneNumber, SubscriptionType, SubscriptionStatus, SubscriptionStart, SubscriptionEnd, SubscriptionPrice)
VALUES 
(NEWID(),'Алексеев Иван Сергеевич', 'aleseev@example.com', '+79001112233', 'Infinity', 'Active', '2023-01-01', '2023-12-31', 2800.00),
(NEWID(),'Борисова Мария Петровна', 'borisova@example.com', '+79002223344', 'Smart', 'Not Paid', '2023-03-01', '2023-05-31', 2400.00),
(NEWID(),'Васильева Анна Викторовна', 'vasilieva@example.com', '+79003334455', 'Light', 'Active', '2023-01-15', '2023-04-15', 1700.00),
(NEWID(),'Григорьев Николай Андреевич', 'grigoriev@example.com', '+79004445566', 'Infinity', 'Active', '2023-02-01', '2024-01-31', 2800.00),
(NEWID(),'Дмитриев Олег Сергеевич', 'dmitriev@example.com', '+79005556677', 'Smart', 'Not Paid', '2023-04-01', '2023-06-30', 2400.00),
(NEWID(),'Евдокимова Надежда Александровна', 'evdokimova@example.com', '+79006667788', 'Light', 'Active', '2023-02-15', '2023-05-15', 1700.00),
(NEWID(),'Жукова Екатерина Павловна', 'zhukova@example.com', '+79007778899', 'Infinity', 'Not Paid', '2023-05-01', '2024-04-30', 2800.00),
(NEWID(),'Захаров Михаил Иванович', 'zaharov@example.com', '+79008889900', 'Smart', 'Active', '2023-06-01', '2023-08-31', 2400.00),
(NEWID(),'Иванова Ольга Дмитриевна', 'ivanova@example.com', '+79009990011', 'Light', 'Active', '2023-03-01', '2023-06-01', 1700.00),
(NEWID(),'Кузнецова Татьяна Сергеевна', 'kuznetsova@example.com', '+79001112200', 'Infinity', 'Active', '2023-07-01', '2024-06-30', 2800.00),
(NEWID(),'Алексеев Иван Сергеевич', 'aleseev1@example.com', '+79001112231', 'Infinity', 'Active', '2023-01-01', '2023-12-31', 2800.00),
(NEWID(),'Борисова Мария Петровна', 'borisova1@example.com', '+79002223341', 'Smart', 'Not Paid', '2023-03-01', '2023-05-31', 2400.00),
(NEWID(),'Васильева Анна Викторовна', 'vasilieva1@example.com', '+79003334451', 'Light', 'Active', '2023-01-15', '2023-04-15', 1700.00),
(NEWID(),'Григорьев Николай Андреевич', 'grigoriev1@example.com', '+79004445561', 'Infinity', 'Active', '2023-02-01', '2024-01-31', 2800.00),
(NEWID(),'Дмитриев Олег Сергеевич', 'dmitriev1@example.com', '+79005556671', 'Smart', 'Not Paid', '2023-04-01', '2023-06-30', 2400.00),
(NEWID(),'Евдокимова Надежда Александровна', 'evdokimova1@example.com', '+79006667781', 'Light', 'Active', '2023-02-15', '2023-05-15', 1700.00),
(NEWID(),'Жукова Екатерина Павловна', 'zhukova1@example.com', '+79007778891', 'Infinity', 'Not Paid', '2023-05-01', '2024-04-30', 2800.00),
(NEWID(),'Захаров Михаил Иванович', 'zaharov1@example.com', '+79008889901', 'Smart', 'Active', '2023-06-01', '2023-08-31', 2400.00),
(NEWID(),'Иванова Ольга Дмитриевна', 'ivanova1@example.com', '+79009990021', 'Light', 'Active', '2023-03-01', '2023-06-01', 1700.00),
(NEWID(),'Кузнецова Татьяна Сергеевна', 'kuznetsova1@example.com', '+79001112201', 'Infinity', 'Active', '2023-07-01', '2024-06-30', 2800.00),
(NEWID(),'Смирнов Дмитрий Иванович', 'smirnov1@example.com', '+79001110001', 'Infinity', 'Active', '2023-02-01', '2023-11-30', 2800.00),
(NEWID(),'Михайлова Виктория Сергеевна', 'mikhailova1@example.com', '+79002220002', 'Light', 'Active', '2023-05-01', '2023-10-31', 1700.00),
(NEWID(),'Попов Алексей Николаевич', 'popov1@example.com', '+79003330003', 'Smart', 'Not Paid', '2023-04-01', '2023-07-31', 2400.00),
(NEWID(),'Козлов Игорь Александрович', 'kozlov1@example.com', '+79004440004', 'Infinity', 'Not Paid', '2023-03-01', '2024-02-29', 2800.00),
(NEWID(),'Новикова Ирина Олеговна', 'novikova1@example.com', '+79005550005', 'Smart', 'Active', '2023-06-01', '2023-09-30', 2400.00),
(NEWID(),'Соколова Елена Николаевна', 'sokolova1@example.com', '+79006660006', 'Light', 'Not Paid', '2023-07-01', '2023-10-31', 1700.00),
(NEWID(),'Лебедев Артем Евгеньевич', 'lebedev1@example.com', '+79007770007', 'Infinity', 'Active', '2023-01-01', '2023-12-31', 2800.00),
(NEWID(),'Павлова Марина Андреевна', 'pavlova1@example.com', '+79008880008', 'Smart', 'Active', '2023-08-01', '2023-11-30', 2400.00),
(NEWID(),'Кириллов Николай Александрович', 'kirillov1@example.com', '+79009990009', 'Light', 'Active', '2023-03-15', '2023-06-15', 1700.00),
(NEWID(),'Сидорова Алёна Михайловна', 'sidorova1@example.com', '+79001111210', 'Infinity', 'Not Paid', '2023-04-01', '2024-03-31', 2800.00),
(NEWID(),'Фролов Михаил Олегович', 'frolov1@example.com', '+79002222211', 'Smart', 'Active', '2023-06-01', '2023-09-30', 2400.00),
(NEWID(),'Гусева Наталья Викторовна', 'guseva1@example.com', '+79003333212', 'Light', 'Active', '2023-01-01', '2023-04-30', 1700.00),
(NEWID(),'Никифоров Андрей Сергеевич', 'nikiforov1@example.com', '+79004444213', 'Infinity', 'Active', '2023-02-01', '2024-01-31', 2800.00),
(NEWID(),'Тихонова Елена Николаевна', 'tikhonova1@example.com', '+79005555214', 'Smart', 'Not Paid', '2023-05-01', '2023-08-31', 2400.00),
(NEWID(),'Медведев Артём Николаевич', 'medvedev1@example.com', '+79006666215', 'Light', 'Active', '2023-03-01', '2023-06-30', 1700.00),
(NEWID(),'Гончарова Анна Викторовна', 'goncharova1@example.com', '+79007777216', 'Infinity', 'Not Paid', '2023-01-01', '2023-12-31', 2800.00),
(NEWID(),'Сафронов Николай Алексеевич', 'safronov1@example.com', '+79008888217', 'Smart', 'Active', '2023-06-01', '2023-09-30', 2400.00),
(NEWID(),'Елисеева Татьяна Сергеевна', 'eliseeva1@example.com', '+79009999218', 'Light', 'Active', '2023-04-01', '2023-07-31', 1700.00),
(NEWID(),'Воробьёв Андрей Александрович', 'vorobyov1@example.com', '+79001111319', 'Infinity', 'Active', '2023-02-01', '2024-01-31', 2800.00),
(NEWID(),'Карасёва Ольга Дмитриевна', 'karaseva1@example.com', '+79002222320', 'Smart', 'Not Paid', '2023-05-01', '2023-08-31', 2400.00),
(NEWID(),'Чернов Пётр Сергеевич', 'chernov1@example.com', '+79003333321', 'Light', 'Active', '2023-01-15', '2023-04-15', 1700.00),
(NEWID(),'Федоров Антон Николаевич', 'fedorov1@example.com', '+79004444322', 'Infinity', 'Not Paid', '2023-03-01', '2024-02-29', 2800.00),
(NEWID(),'Капустина Мария Ивановна', 'kapustina1@example.com', '+79005555323', 'Smart', 'Active', '2023-06-01', '2023-09-30', 2400.00),
(NEWID(),'Баранова Виктория Александровна', 'baranova1@example.com', '+79006666324', 'Light', 'Active', '2023-02-15', '2023-05-15', 1700.00),
(NEWID(),'Гаврилов Сергей Александрович', 'gavrilov1@example.com', '+79007777325', 'Infinity', 'Active', '2023-01-01', '2023-12-31', 2800.00),
(NEWID(),'Ермакова Анна Дмитриевна', 'ermakova1@example.com', '+79008888326', 'Smart', 'Not Paid', '2023-05-01', '2023-08-31', 2400.00),
(NEWID(),'Крылов Александр Сергеевич', 'krylov1@example.com', '+79009999327', 'Light', 'Active', '2023-03-01', '2023-06-30', 1700.00),
(NEWID(),'Рябова Екатерина Андреевна', 'ryabova1@example.com', '+79001111428', 'Infinity', 'Active', '2023-02-01', '2024-01-31', 2800.00);

-- Таблица спортивного инвентаря
CREATE TABLE Equipment (
    ID UNIQUEIDENTIFIER  PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Status nvarchar(50) NOT NULL,
    Quantity INT NOT NULL,
    InRepair INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- Вставка данных в таблицу спортивного инвентаря
INSERT INTO Equipment (ID, Name, Status, Quantity, InRepair, Price)
VALUES 
(NEWID(),'Гантели 5 кг', 'Available', 20, 2, 1500.00),
(NEWID(),'Беговая дорожка', 'Available', 5, 1, 75000.00),
(NEWID(),'Штанга 20 кг', 'Available', 10, 0, 10000.00),
(NEWID(),'Велотренажер', 'Available', 8, 1, 30000.00),
(NEWID(),'Блины 1.25 кг', 'Available', 30, 0, 300.00),
(NEWID(),'Блины 2.5 кг', 'Available', 25, 0, 500.00),
(NEWID(),'Блины 5 кг', 'Available', 20, 1, 1000.00),
(NEWID(),'Блины 10 кг', 'Available', 15, 0, 1500.00),
(NEWID(),'Тренажер для кора', 'Available', 4, 1, 45000.00),
(NEWID(),'Тренажер для ног', 'Not Available', 3, 2, 55000.00);

-- Таблица тренировок
CREATE TABLE Workouts (
    ID UNIQUEIDENTIFIER  PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    TotalTime INT NOT NULL, -- в минутах
    TrainerFullName VARCHAR(255) NOT NULL
);

-- Вставка данных в таблицу тренировок
INSERT INTO Workouts (ID, Name, StartTime, EndTime, TotalTime, TrainerFullName)
VALUES 
(NEWID(),'Утренняя йога', '2023-01-10 08:00:00', '2023-01-10 09:00:00', 60, 'Федорова Мария Ивановна'),
(NEWID(),'Силовая тренировка', '2023-01-10 10:00:00', '2023-01-10 11:30:00', 90, 'Волков Олег Андреевич');

-- Таблица подсчета статистики
CREATE TABLE Statts (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    MonthYear DATE NOT NULL,
    TotalSubscriptionsRevenue DECIMAL(10, 2) NOT NULL,
    TrainersSalaryExpense DECIMAL(10, 2) NOT NULL,
    ManagersSalaryExpense DECIMAL(10, 2) NOT NULL,
    RepairCosts DECIMAL(10, 2) NOT NULL,
    EquipmentPurchaseCosts DECIMAL(10, 2) NOT NULL
);

-- Пример вставки данных в таблицу статистики
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts)
VALUES 
(NEWID(),'2023-01-01', 240000.00, 680000.00, 148000.00, 10000.00, 50000.00);

INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-02-01', 350000, 300000, 150000, 20000, 10000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-03-01', 400000, 310000, 155000, 21000, 12000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-04-01', 350000, 320000, 160000, 22000, 14000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-05-01', 400000, 300000, 165000, 23000, 16000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-06-01', 350000, 310000, 150000, 24000, 18000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-07-01', 400000, 320000, 155000, 20000, 20000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-08-01', 350000, 300000, 160000, 21000, 10000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-09-01', 400000, 310000, 165000, 22000, 12000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-10-01', 350000, 320000, 150000, 23000, 14000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-11-01', 400000, 300000, 155000, 24000, 16000);
INSERT INTO Statts (ID, MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts) VALUES (NEWID(), '2023-12-01', 350000, 310000, 160000, 20000, 18000);

