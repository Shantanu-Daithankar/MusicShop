Feature: Get albums by filter categories
	In order to display the available albums for sales
	As a product owner
	I want to retrieve albums by various filter conditions
	So that the albums can be displayed to a prospective buyer as per choice

@getAlbums
Scenario: get album data by artist name 
	Given The MusicShop app is online
	And I have entered the name of the artists :
	| ArtistName |
	| Metallica  |		
	When I request for albums data
	Then the result should be the album's information as below :
	| AlbumId | Title                  | ArtistId |
	| 35      | Garage Inc. (Disc 1)   | 50       |
	| 148     | Black Album            | 50       |
	| 149     | Garage Inc. (Disc 2)   | 50       |
	| 150     | Kill 'Em All           | 50       |
	| 151     | Load                   | 50       |
	| 152     | Master Of Puppets      | 50       |
	| 153     | ReLoad                 | 50       |
	| 154     | Ride The Lightning     | 50       |
	| 155     | St. Anger              | 50       |
	| 156     | ...And Justice For All | 50       |
