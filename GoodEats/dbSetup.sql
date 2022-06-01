CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS restaurants(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Restaurant Name',
  address varchar(255) COMMENT 'Restaurant Address',
  image varchar(255) COMMENT 'Restaurant Image'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS reviews(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) COMMENT 'User Id',
  restaurantId INT COMMENT 'Restaurant Id',
  rating INT COMMENT 'Rating',
  comment varchar(255) COMMENT 'Comment'
) default charset utf8 COMMENT '';


/* FAKE DATA */
/* SECTION Accounts */
INSERT INTO accounts
(id, name, email, picture) 
VALUES 
('BGR123', 'Baby Ramsey', 'bgr@cooks.com', 'https://pyxis.nymag.com/v1/imgs/f3d/e8f/11fe76ef448141b59f33a44d68a85f664a-27-gordon-ramsay-baby.rsquare.w700.jpg');


INSERT INTO accounts
(id, name, email, picture) 
VALUES 
('GF123', 'Guy Fieri', 'DDD@food.com', 'https://i1.sndcdn.com/avatars-000479917803-scdh9f-t500x500.jpg');

INSERT INTO accounts
(id, name, email, picture) 
VALUES 
('AG123', 'AntonEgo', 'IHATEFOOD@food.com', 'https://static.wikia.nocookie.net/disney/images/9/91/Profile_-_Anton_Ego.jpg/revision/latest?cb=20190626003849');


/* SECTION Restaurants */
INSERT INTO restaurants
(name, address, image)
VALUES
('Big B Cheese', '123 Main St', 'https://images.unsplash.com/photo-1542834369-f10ebf06d3e0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Papa Marks Pizza', '123 1st St', 'https://images.unsplash.com/photo-1542834369-f10ebf06d3e0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80');


INSERT INTO restaurants
(name, address, image)
VALUES
('Big Js Juice Hut', '123 Sandbar Ave', 'https://images.unsplash.com/photo-1603569283847-aa295f0d016a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1372&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Sandy Sams Sandwiches', '124 Sandbar Ave', 'https://images.unsplash.com/photo-1621800043295-a73fe2f76e2c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1474&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Harrys Hams', '124 Utah ln', 'https://images.unsplash.com/photo-1524438418049-ab2acb7aa48f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Fowler Chicken', '124 Cat Dr', 'https://images.unsplash.com/photo-1606755962773-d324e0a13086?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Oh My Cookie', '124 Resume Ave', 'https://images.unsplash.com/photo-1622467827417-bbe2237067a9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1374&q=80');

INSERT INTO restaurants
(name, address, image)
VALUES
('Aloha Zachs', '124 Hawaii blvd', 'https://images.unsplash.com/photo-1579887829494-5b736888265a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80');