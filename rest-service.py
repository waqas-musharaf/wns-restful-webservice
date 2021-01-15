from flask import Flask, request
from flask_restful import Resource, Api
import json
import requests
import re

# Flask constructor
app = Flask(__name__)
# Flask RESTful constructor
api = Api(app)

# Default path (homepage) returns welcome message
class Home(Resource):
	def get(self):
		return('Connected to rest-service')

class CatFact(Resource):
	def get(self):
		# Performs 'GET' request from API URL provided
		url = "https://cat-fact.herokuapp.com/facts/random"
		r = requests.get(url)
		
		# Trims and formats response text using RegEx
		fact = ' '.join(r.text.split())		
		startIndex = re.search(r'\"text\":\"', fact).end()
		fact = fact[startIndex:]		
		endIndex = re.search(r'\",\"', fact).start()
		fact = fact[:endIndex]
		
		# Returns formatted cat fact
		return ('Cat Fact: ' + fact)

class Dictionary(Resource):		
	def get(self, word):
		# Hard-coded API ID and API Key associated with my Oxford Dictionary API account 
		app_id  = ""
		app_key  = ""
		
		# Performs 'GET' request from API URL provided, in conjunction with API ID, API Key and user-provided search term
		url = "https://od-api.oxforddictionaries.com/api/v2/entries/en-us/" + word.lower()
		r = requests.get(url, headers = {"app_id": app_id, "app_key": app_key})
		
		# Trims and formats response text
		definition = ' '.join(r.text.replace("\"", "'").split())
		
		# If the response text contains an error, uses RegEx to trim and return the error
		if (re.search(r'{ \'error\': \'', definition)):
			startIndex = re.search(r'{ \'error\': \'', definition).end()
			definition = definition[startIndex:]
			endIndex = re.search(r'\' }', definition).start()
			definition = 'Error: ' + definition[:endIndex]
			return(definition)
		
		# If the response text contains a definition, uses RegEx to trim and return the definition
		elif (re.search(r'{ \'definitions\': \[ \'', definition)):
			startIndex = re.search(r'{ \'definitions\': \[ \'', definition).end()
			definition = definition[startIndex:]
			endIndex = re.search(r'\' \],', definition).start()
			definition = definition[:endIndex]
			return('\'' + word.capitalize() + '\' Definition: ' + definition)
		
		# Else, returns a non-specific catch-all error message
		else:
			definition = 'Error: No definition or error detected within dictionary output'
			return(definition)

class NoWord_Dictionary(Resource):
	def get(self):
		# If the user requests the dictionary API without a search parameter, returns an error message
		return('Error: No word parameter provided to look-up, please try again with a word to define')

class Location(Resource):
	def get(self,ip):
		# Hard-coded API Token associated with my IPInfo API account
		token = "86ab1ccc7cdae7"
		
		# Performs 'GET' request from API URL provided, in conjunction with API Token and user-provided search IP address
		url = "https://ipinfo.io/" + ip + "?token=" + token
		r = requests.get(url)
		
		# Trims and formats response text
		info = ' '.join(r.text.replace("\"", "'").replace("{", "").replace("}", "").split())
		
		# If the response text contains an error, uses RegEx to trim and return the error
		if (re.search(r'\'error\': \'', info)):
			if (re.search(r'\'message\': \'', info)):
				startIndex = re.search(r'\'message\': \'', info).end()
				info = 'Error: ' + info[startIndex:-1]
		
		# Returns formatted IP location information
		return(info)

class My_Location(Resource):
	def get(self):
		# Hard-coded API Token associated with my IPInfo API account
		token = "86ab1ccc7cdae7"
		
		# Performs 'GET' request from API URL provided, in conjunction with API Token
		url = "https://ipinfo.io/?token=" + token
		r = requests.get(url)
		
		# Trims and formats response text
		info = ' '.join(r.text.replace("\"", "'").replace("{", "").replace("}", "").split())
		
		# Returns formatted IP location information
		return(info)

# Maps resources to service API with http parameters
api.add_resource(Home, '/')
api.add_resource(CatFact, '/catfact')
api.add_resource(Dictionary, '/dictionary/<string:word>')
api.add_resource(NoWord_Dictionary, '/dictionary')
api.add_resource(Location, '/location/<string:ip>')
api.add_resource(My_Location, '/location')

# If service is called directly, shows debugging tools in prompt when running
if __name__ == '__main__':
	app.run(debug=True)
