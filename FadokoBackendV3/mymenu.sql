-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Ápr 15. 08:59
-- Kiszolgáló verziója: 10.4.16-MariaDB
-- PHP verzió: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `mymenu`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admin`
--

CREATE TABLE `admin` (
  `AdId` int(11) NOT NULL,
  `AdName` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `AdPermission` varchar(10) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `AdEmail` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `AdPhone` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Active` int(2) NOT NULL,
  `Salt` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Hash` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `admin`
--

INSERT INTO `admin` (`AdId`, `AdName`, `AdPermission`, `AdEmail`, `AdPhone`, `Active`, `Salt`, `Hash`) VALUES
(1, 'Fazekas Réka', '9', 'f@f.hu', '+3636', 1, 'hyD7KTz06AdOpATFk7KWycl2NRYH0AQuTmoEfFdcsyiZki1xysuMLmPoBBH52rR6', '7fdfcacc1bbc99a48778a18770ae72321a12e54417a05f1f8296368f4265e35d'),
(2, 'a', '9', 'p@p.hu', '+36', 1, 'hyD7KTz06AdOpATFk7KWycl2NRYH0AQuTmoEfFdcsyiZki1xysuMLmPoBBH52rR6', '7fdfcacc1bbc99a48778a18770ae72321a12e54417a05f1f8296368f4265e35d');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `commodity`
--

CREATE TABLE `commodity` (
  `CoId` int(11) NOT NULL,
  `CoName` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `CoUnit` int(10) NOT NULL,
  `CoCat` int(3) NOT NULL,
  `CoPrice` int(10) NOT NULL,
  `CoActive` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `commodity`
--

INSERT INTO `commodity` (`CoId`, `CoName`, `CoUnit`, `CoCat`, `CoPrice`, `CoActive`) VALUES
(1, 'sonka', 1, 2, 12, 0),
(2, 'sajt', 1, 3, 34, 0),
(3, 'szalámi', 1, 2, 56, 0),
(4, 'polip', 1, 2, 67, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

CREATE TABLE `orders` (
  `OrId` int(11) NOT NULL,
  `AdId` int(11) DEFAULT NULL,
  `Name` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Address` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Phone` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `LogDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `product`
--

CREATE TABLE `product` (
  `PrId` int(11) NOT NULL,
  `PrName` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `PrSize` varchar(10) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `PrOther` varchar(80) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `PrUrl` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `PrActive` int(2) NOT NULL,
  `PrPrice` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `product`
--

INSERT INTO `product` (`PrId`, `PrName`, `PrSize`, `PrOther`, `PrUrl`, `PrActive`, `PrPrice`) VALUES
(1, 'Sonkás pizza', '25', 'Sonka, sajt', '', 0, 1500),
(2, 'szalámis pizza', '25', 'szalámi, sajt', '', 0, 1600),
(3, 'tenger gyümölcsei', '', 'kagyló, rák, polip', '', 0, 2000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `receiptconn`
--

CREATE TABLE `receiptconn` (
  `ReId` int(7) NOT NULL,
  `PrId` int(11) NOT NULL,
  `CoId` int(11) NOT NULL,
  `Quantity` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `receiptconn`
--

INSERT INTO `receiptconn` (`ReId`, `PrId`, `CoId`, `Quantity`) VALUES
(1, 1, 1, 2),
(2, 1, 2, 1),
(3, 2, 3, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tetelconn`
--

CREATE TABLE `tetelconn` (
  `OrId` int(11) NOT NULL,
  `PrId` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`AdId`);

--
-- A tábla indexei `commodity`
--
ALTER TABLE `commodity`
  ADD PRIMARY KEY (`CoId`);

--
-- A tábla indexei `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrId`),
  ADD KEY `CuId` (`AdId`);

--
-- A tábla indexei `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`PrId`);

--
-- A tábla indexei `receiptconn`
--
ALTER TABLE `receiptconn`
  ADD PRIMARY KEY (`ReId`),
  ADD KEY `CoId` (`CoId`),
  ADD KEY `PrId` (`PrId`);

--
-- A tábla indexei `tetelconn`
--
ALTER TABLE `tetelconn`
  ADD PRIMARY KEY (`OrId`),
  ADD KEY `PrId` (`PrId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `admin`
--
ALTER TABLE `admin`
  MODIFY `AdId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `commodity`
--
ALTER TABLE `commodity`
  MODIFY `CoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `orders`
--
ALTER TABLE `orders`
  MODIFY `OrId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `receiptconn`
--
ALTER TABLE `receiptconn`
  MODIFY `ReId` int(7) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `tetelconn`
--
ALTER TABLE `tetelconn`
  MODIFY `OrId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`AdId`) REFERENCES `admin` (`AdId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `receiptconn`
--
ALTER TABLE `receiptconn`
  ADD CONSTRAINT `receiptconn_ibfk_1` FOREIGN KEY (`PrId`) REFERENCES `product` (`PrId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receiptconn_ibfk_2` FOREIGN KEY (`CoId`) REFERENCES `commodity` (`CoId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `tetelconn`
--
ALTER TABLE `tetelconn`
  ADD CONSTRAINT `tetelconn_ibfk_1` FOREIGN KEY (`OrId`) REFERENCES `orders` (`OrId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tetelconn_ibfk_2` FOREIGN KEY (`PrId`) REFERENCES `product` (`PrId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
