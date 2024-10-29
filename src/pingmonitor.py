#!./venv/bin/python
import os
from data.queries import select_websites

def main():
	# get all websites
	websites = select_websites()

	# ping all websites
	for website in websites:
		result = os.popen(f"ping -c 1 {website.domain}").read()

	# parse ping results
	# store ping results

	print("hello, world")


if __name__ == "__main__": 
	main()
