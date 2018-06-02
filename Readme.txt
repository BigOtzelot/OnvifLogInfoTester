OnvifLogInfoTester

This small program checks if camera does support the ONVIF-functions:
GetSystemLog, GetSystemSupportInformation, GetSystemBackup and GetSystemUris

It was developed for onvif-spotlight.bemyapp.com

The program will connect to the camera-address put into the corresponding field.
Port can be used by printing "ip-address:port".

If you leave "Enter IP" empty, the program will connect to all six onvif-spotlight.bemyapp.com cameras after each other.

Or you can use these parameters:

Brand	  Model				   IP				Port RTSP User		Password
Bosch	  Dinion7000HD	       193.159.244.134	80	 554  service	Xbks8tr8vT
Bosch	  Autodom7000	       193.159.244.132	80	 554  service	Xbks8tr8vT
Axis	  AXIS Q3505-V Mark II 195.60.68.239	80	 554  operator	Onv!f2018
Uniview   HIC6622HX22-5CIR-U   61.164.52.166:88	88	 555  admin	    Uniview2018
Dahua	  DH-IPC-HDW4830EM-AS  60.191.94.122	8086 554  admin	    a1b2c3d4
Hikvision DS_2DE2204IW-DE3/W   123.157.208.28	81	 555  admin	    abcd1234
