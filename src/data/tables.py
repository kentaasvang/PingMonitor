

class Website:

	tablename = "website"

	def __init__(self, website_id, name, domain):
		self.website_id = website_id
		self.name = name
		self.domain = domain


class PingResult:
	def __init__(
		self,
		ping_result_id,
		website_id,
		date,
		p_bytes,
		p_from,
		ip,
		icmp_seq,
		ttl,
		time
	):
		
		self.ping_result_id = ping_result_id
		self.website_id = website_id
		self.date = date
		self.p_bytes = p_bytes
		self.p_from = p_from
		self.ip = ip
		self.icmp_seq = icmp_seq
		self.ttl = ttl
		self.time = time
		
