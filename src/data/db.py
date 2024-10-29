import sqlite3


def _get_connection():
	con = sqlite3.connect("./pingmonitor.db")

	# enable foreign key constraint
	# must be set on each connection
	con.execute("PRAGMA foreign_keys=1")
	return con


def _get_cursor():
	cur = _get_connection()
	return cur

	
