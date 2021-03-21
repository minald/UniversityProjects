from bs4 import BeautifulSoup 
import requests 
 
class Film: 
 name = "" 
 director = "" 
 rating = "" 
 genre = "" 
 year = "" 
 authors = ""
 date =  ""
 duration = ""
 def to_string(self): 
  print("Name: " + self.name + "; " + self.director)
  print("Rating: " + self.rating + "; Authors: " + self.authors)
  print("Year: " + self.year + "; Genre: " + self.genre)
  print("Duration: " + self.duration + "; Date: " + self.date)

def get_soup_by_link(link):
	response = requests.get(link) 
	return BeautifulSoup(response.text, 'html.parser')

def parse_film(link): 
 soup = get_soup_by_link(link)
 film = Film() 
 
 td_with_data = soup.find('td', {'class': 'post b-event-post'}) 
 table_movie_info = td_with_data.find('table', {'class': 'movie_info'}) 
 table_movie_rating = td_with_data.find('table', {'class': 'movie_rating'})
 
 film.name = td_with_data.h1.string 
 film.director = parse_director(table_movie_info)
 film.rating = parse_rating(table_movie_rating)
 film.year = parse_year(table_movie_info)
 film.genre = parse_genre(table_movie_info) 
 film.authors = parse(table_movie_info, 'author') 
 film.date = parse(table_movie_info, 'date') 
 film.duration = parse(table_movie_info, 'duration') 
 return film 
 
def parse_rating(table_movie_rating): 
 try: 
  return table_movie_rating.tbody.tr.td.div.span.string 
 except: 
  return "Unknown" 
 
def parse_genre(table_movie_info): 
  try: 
    return table_movie_info.find('td', {'class': 'genre'}).p.a.string
  except: 
    return "Unknown" 
  
def parse_year(table_movie_info):
	try:
		return table_movie_info.find('td', {'class': 'year'}).a.string
	except:
		return "Unknown"
		
def parse(table_movie_info, class_name):
	try:
		return table_movie_info.find('td', {'class': class_name}).string
	except:
		return "Unknown"
  
def parse_director(element):
    sibling = element.next_sibling
    if sibling == "\n":
        return parse_director(sibling)
    elif sibling.tbody is None:
    	result = sibling.string
    	if result is not None:
    		return result
    return "Director is unknown"

main_link = 'https://afisha.tut.by/film/'
soup = get_soup_by_link(main_link)
films_li = soup.findAll('li', {'class': 'lists__li'}) 
links = [] 
for film_li in films_li: 
  film_links = film_li.findAll('a', {'class': 'name'}) 
  if len(film_links) != 0: 
    link = film_links[0]['href'] 
    if link.startswith(main_link) and '?utm_source' not in link: 
      links.append(link) 
 
results = dict.fromkeys(links, Film())
for key in results: 
 print("-------------------------------------------------------------------")
 print(key)
 print("-------------------------------------------------------------------")
 try:
   film = parse_film(key) 
   print(film.to_string())
 except Exception as e:
   print(e)
 print("-------------------------------------------------------------------")
 print("\n")
 