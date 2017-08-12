#include "stdafx.h"
#include <sstream>
#include <SFML/Graphics.hpp>
#include "Timber.h"
#include <random>
#include <SFML/FileInputStream.hpp>
#include <fstream>
#include <iostream>
#include <math.h> 

//making code easier to type with "using namespace"
using namespace sf;

//making a bool to check if the users mouse is hovered over the sprite
bool isSpriteHover(sf::FloatRect sprite, sf::Vector2f mp)
{
	if (sprite.contains(mp))
	{
		return true;
	}
	return false;
}

//using main to set up the game - used the timber tutorial
//to get the main function to display and close working
int main()
{
	hRes = 1366;
	vRes = 768;

	tileSize = 100;

	VideoMode vm(hRes, vRes);

	RenderWindow window(vm, "Tile Editor");

	InitGame();

	Vector2f mp;

	//saving the users mouse position
	mp.x = Mouse::getPosition(window).x;
	mp.y = Mouse::getPosition(window).y;

	indX = 0;
	indY = 0;

	tileIndex = 0;

	//tileStylesAmount = 6;

	tileTypeNumber = 0; //max of 3

	while (window.isOpen())
	{
		Event event;

		while (window.pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.close();

			//creating my two buttons for loading and saving
			if (isSpriteHover(spriteLoadButton.getGlobalBounds(), Vector2f(event.mouseButton.x, event.mouseButton.y)) == true)
			{
				if (event.type == Event::MouseButtonReleased &&  event.mouseButton.button == Mouse::Left)
				{
					LoadData();
				}
			}

			if (isSpriteHover(spriteSaveButton.getGlobalBounds(), Vector2f(event.mouseButton.x, event.mouseButton.y)) == true)
			{
				if (event.type == Event::MouseButtonReleased &&  event.mouseButton.button == Mouse::Left)
				{
					SaveData();
				}
			}

			for (int row = 0; row < tileWidth; row++)
			{
				for (int column = 0; column < tileHeight; column++)
				{
					if (isSpriteHover(spriteTile[row][column].getGlobalBounds(), Vector2f(event.mouseButton.x, event.mouseButton.y)) == true)
					{
						if (event.type == Event::MouseButtonReleased &&  event.mouseButton.button == Mouse::Left)
						{
							std::cout << row;
							std::cout << column;

							indX = row;
							indY = column;

							spriteTile[row][column];

							if (TileStyle[row][column] <= 6)
							{
								TileStyle[row][column] += 1;
								if (TileStyle[row][column] >= 6)
								{
									TileStyle[row][column] = 0;
								}
							}
						}
					}
				}
			}

		}

		//closing the editor when the user hits escape
		if (Keyboard::isKeyPressed(Keyboard::Escape))
		{
			window.close();
		}

		window.clear();

		//setting up the tile position and saving in an 2D array
		for (row = 0; row < tileWidth; row++)
		{
			for (column = 0; column < tileHeight; column++)
			{
				setTileType(TileStyle[row][column], row, column);
				spriteTile[row][column].setPosition(row*tileSize, column*tileSize);
				window.draw(spriteTile[row][column]);
			}
		}

		//setting the positions for the save and load buttons
		spriteSaveButton.setPosition(1050, 650);
		window.draw(spriteSaveButton);

		spriteLoadButton.setPosition(820, 650);
		window.draw(spriteLoadButton);

		window.display();
	}

	return 0;
}

void InitGame()
{
	//saving the textures in the tile array
	textureTile[0].loadFromFile("graphics/dirt.png");
	textureTile[1].loadFromFile("graphics/dirtTwo.png");
	textureTile[2].loadFromFile("graphics/stone.png");
	textureTile[3].loadFromFile("graphics/grass.png");
	textureTile[4].loadFromFile("graphics/cloudTile.png");
	textureTile[5].loadFromFile("graphics/cloudTile_blank.png");

	for (int i = 0; i < 6; i++)
	{
		tileType[i].setTexture(textureTile[i]);
	}

	//textureHoverButton.loadFromFile("graphics/highlightedTile.png");
	//spriteHoverButton.setTexture(textureHoverButton);

	//loading the save and load button textures
	textureSaveButton.loadFromFile("graphics/save.png");
	spriteSaveButton.setTexture(textureSaveButton);

	textureLoadButton.loadFromFile("graphics/load.png");
	spriteLoadButton.setTexture(textureLoadButton);

	textureDirt.loadFromFile("graphics/dirt.png");
	spriteDirt.setTexture(textureDirt);

	textureDirtTwo.loadFromFile("graphics/dirtTwo.png");
	spriteDirtTwo.setTexture(textureDirtTwo);

	textureStone.loadFromFile("graphics/stone.png");
	spriteStone.setTexture(textureStone);

	textureGrass.loadFromFile("graphics/grass.png");
	spriteGrass.setTexture(textureGrass);

	textureCloud.loadFromFile("graphics/cloudTile.png");
	spriteCloud.setTexture(textureCloud);

	textureCloud_blank.loadFromFile("graphics/cloudTile_blank.png");
	spriteCloud_blank.setTexture(textureCloud_blank);

}

//setting each tile position to a tile type
void setTileType(int colour, int row, int column)
{
	spriteTile[row][column] = tileType[colour];
}

//displaying the tiles in an 8x8 grid
void setTileStyle()
{
	for (row = 0; row < tileWidth; row++)
	{
		for (column = 0; column < tileHeight; column++)
		{
			TileStyle[row][column] = rand() % 4;
		}
	}
}

//loading the data from a text file saved in the project folder
void LoadData()
{
	tileWidth = 8;
	tileHeight = 8;

	std::ifstream myData("userData/data.txt");

	char s;
	if (myData.is_open())
	{
		count = 0;
		tRow = 0;
		tCol = 0;

		while (myData.get(s))
		{
			fileData[count] = s - '0';

			tRow = count % tileWidth;
			tCol = count / tileHeight;

			TileStyle[tRow][tCol] = fileData[count];
			count++;
		}
	}

	else
	{

	}
	//closing the file once there is no more data to load
	myData.close();

}

//saving the tile data to a text file saved inside the project folder
void SaveData()
{
	std::ofstream myfile;
	myfile.open("userData/data.txt");

	count = 0;

	for (row = 0; row < tileWidth; row++)
	{
		for (column = 0; column < tileHeight; column++)
		{
			fileData[count] = TileStyle[column][row];
			myfile << fileData[count];
			count++;
		}
	}

	//closing the file once there is no more data to save
	myfile.close();
}