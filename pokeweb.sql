-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-05-2021 a las 21:18:16
-- Versión del servidor: 10.4.16-MariaDB
-- Versión de PHP: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `pokeweb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pokemon`
--

CREATE TABLE `pokemon` (
  `Numero` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Altura` float DEFAULT NULL,
  `Peso` float DEFAULT NULL,
  `Categoria` varchar(45) DEFAULT NULL,
  `Habilidad` varchar(45) DEFAULT NULL,
  `Tipos` varchar(255) DEFAULT '"Ninguno"',
  `ImagenURL` varchar(255) DEFAULT NULL,
  `SonidoURL` varchar(255) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pokemon`
--

INSERT INTO `pokemon` (`Numero`, `Nombre`, `Descripcion`, `Altura`, `Peso`, `Categoria`, `Habilidad`, `Tipos`, `ImagenURL`, `SonidoURL`) VALUES
(0, 'Yiscapier', 'Este Pokemon solo se calma con Pan, ataca/trabaja 24/7. Le gusta programar. ¿Primer Pokemon Programador?', 1.79, 80, '¿¿??', 'Dormir', 'Carne', 'https://pbs.twimg.com/profile_images/1374429447835684864/o9wFsAF3_400x400.jpg', 'https://yisus.dev/assets/yiscapier.mp3'),
(1, 'Bulbasaur', 'Este Pokémon nace con una semilla en el lomo, que brota con el paso del tiempo.', 0.7, 6.9, 'Semilla', 'Espesura', 'Planta, Veneno', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png', 'http://play.pokemonshowdown.com/audio/cries/bulbasaur.mp3'),
(2, 'Ivysaur', 'Cuando le crece bastante el bulbo del lomo, pierde la capacidad de erguirse sobre las patas traseras.', 1, 13, 'Semilla', 'Espesura', 'Planta, Veneno', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png', 'https://play.pokemonshowdown.com/audio/cries/ivysaur.mp3'),
(3, 'Venusaur ', 'La planta florece cuando absorbe energía solar, lo cual le obliga a buscar siempre la luz del sol.', 2, 100, 'Semilla', 'Espesura', 'Planta, Veneno', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png', 'https://play.pokemonshowdown.com/audio/cries/venusaur.mp3'),
(4, 'Charmander', 'Prefiere las cosas calientes. Dicen que cuando llueve le sale vapor de la punta de la cola.', 0.6, 8.5, 'Lagartija', 'Mar Llamas', 'Fuego', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png', 'https://play.pokemonshowdown.com/audio/cries/charmander.mp3'),
(5, 'Charmeleon', 'Este Pokémon de naturaleza agresiva ataca en combate con su cola llameante y hace trizas al rival con sus afiladas garras.', 1.1, 19, 'Llama', 'Mar Llamas', 'Fuego', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png', 'https://play.pokemonshowdown.com/audio/cries/charmeleon.mp3'),
(6, 'Charizard', 'Escupe un fuego tan caliente que funde las rocas. Causa incendios forestales sin querer.', 1.7, 90.5, 'Llama', 'Mar Llamas', 'Fuego, Volador', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/006.png', 'https://play.pokemonshowdown.com/audio/cries/charizard.mp3'),
(7, 'Squirtle', '\"Vamo a calmarno\" Cuando retrae su largo cuello en el caparazón, dispara agua a una presión increíble.', 0.5, 9, 'Tortuguita', 'Torrente', 'Agua', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png', 'https://play.pokemonshowdown.com/audio/cries/squirtle.mp3'),
(8, 'Wartortle', 'Se lo considera un símbolo de longevidad. Los ejemplares más ancianos tienen musgo sobre el caparazón.', 1, 22.5, 'Tortuga', 'Torrente', 'Agua', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png', 'https://play.pokemonshowdown.com/audio/cries/wartortle.mp3'),
(9, 'Blastoise', 'Para acabar con su enemigo, lo aplasta con el peso de su cuerpo. En momentos de apuro, se esconde en el caparazón.', 1.6, 85.5, 'Armazón', 'Torrente', 'Agua', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/009.png', 'https://play.pokemonshowdown.com/audio/cries/blastoise.mp3'),
(10, 'Caterpie', 'Para protegerse, despide un hedor horrible por las antenas con el que repele a sus enemigos.', 0.3, 2.9, 'Gusano', 'Polvo Escudo', 'Bicho', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/010.png', 'https://play.pokemonshowdown.com/audio/cries/caterpie.mp3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `Username` varchar(50) NOT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `IsAdmin` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`Username`, `Password`, `IsAdmin`) VALUES
('admin', 'admin', 1),
('user', 'user', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `pokemon`
--
ALTER TABLE `pokemon`
  ADD PRIMARY KEY (`Numero`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
