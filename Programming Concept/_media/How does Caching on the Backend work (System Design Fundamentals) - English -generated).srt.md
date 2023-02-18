```srt
1
00:00:00,000 --> 00:00:03,300
there are only two hard things in

2
00:00:01,620 --> 00:00:06,420
computer science cache and validation

3
00:00:03,300 --> 00:00:08,280
and naming things and I completely agree

4
00:00:06,420 --> 00:00:10,019
with the statement especially with the

5
00:00:08,280 --> 00:00:12,000
first one because whenever you're

6
00:00:10,019 --> 00:00:14,040
designing complex systems like this one

7
00:00:12,000 --> 00:00:16,619
where you have a lot of components

8
00:00:14,040 --> 00:00:18,359
connected to each other and presumably a

9
00:00:16,619 --> 00:00:20,520
high amount of users were talking about

10
00:00:18,359 --> 00:00:22,619
Millions here you want to make sure that

11
00:00:20,520 --> 00:00:25,680
your users get the best experience

12
00:00:22,619 --> 00:00:28,439
because every extra second counts and

13
00:00:25,680 --> 00:00:30,779
costs your business money so this is

14
00:00:28,439 --> 00:00:33,000
where caching comes into play so that

15
00:00:30,779 --> 00:00:35,399
you can it reduce the latency and

16
00:00:33,000 --> 00:00:37,140
optimize your architecture so in this

17
00:00:35,399 --> 00:00:39,540
video You're gonna learn everything you

18
00:00:37,140 --> 00:00:42,120
need to know about back-end caching and

19
00:00:39,540 --> 00:00:44,579
how it fits into such complex system

20
00:00:42,120 --> 00:00:46,559
architectures so this is going to be our

21
00:00:44,579 --> 00:00:48,719
outline for this video first we're gonna

22
00:00:46,559 --> 00:00:50,520
take a look at some use cases and

23
00:00:48,719 --> 00:00:52,559
discuss why you would even need to

24
00:00:50,520 --> 00:00:54,360
consider adding caching to your system

25
00:00:52,559 --> 00:00:56,699
then we're going to take a look at some

26
00:00:54,360 --> 00:00:58,739
cash invalidation strategies because as

27
00:00:56,699 --> 00:00:59,940
we've mentioned before invalidating the

28
00:00:58,739 --> 00:01:01,680
cache is one of the most difficult

29
00:00:59,940 --> 00:01:03,480
difficult things when it comes to

30
00:01:01,680 --> 00:01:06,600
caching and then we're gonna talk about

31
00:01:03,480 --> 00:01:09,360
caching eviction policy so invalidation

32
00:01:06,600 --> 00:01:11,820
strategies answers the question on how

33
00:01:09,360 --> 00:01:14,760
to invalidate your cash while eviction

34
00:01:11,820 --> 00:01:17,159
policies answer the question on when to

35
00:01:14,760 --> 00:01:20,040
invalidate your cash all right because

36
00:01:17,159 --> 00:01:22,439
invalidating the cache is important due

37
00:01:20,040 --> 00:01:24,540
to the reason that your data in the

38
00:01:22,439 --> 00:01:27,240
cache might get stale and yours users

39
00:01:24,540 --> 00:01:29,520
your users might see stale data from the

40
00:01:27,240 --> 00:01:31,680
cache if you never invalidate your cash

41
00:01:29,520 --> 00:01:33,960
or clean it up and then we're also going

42
00:01:31,680 --> 00:01:36,119
to talk about how to implement caching

43
00:01:33,960 --> 00:01:38,579
or rather see how to implement caching

44
00:01:36,119 --> 00:01:42,000
I'm going to use an example of node.js

45
00:01:38,579 --> 00:01:44,640
with redis and build a simple API and

46
00:01:42,000 --> 00:01:47,159
use caching there and then we are going

47
00:01:44,640 --> 00:01:48,960
to talk about when not to use caching

48
00:01:47,159 --> 00:01:51,600
because this is a very important point

49
00:01:48,960 --> 00:01:54,180
that a lot of people miss and people add

50
00:01:51,600 --> 00:01:55,920
caching on every system even if it's if

51
00:01:54,180 --> 00:01:58,380
it even if it doesn't require any

52
00:01:55,920 --> 00:02:01,320
caching and it would be well off without

53
00:01:58,380 --> 00:02:04,439
any caching right so so imagine we have

54
00:02:01,320 --> 00:02:06,479
a small app with the API so it's a

55
00:02:04,439 --> 00:02:08,280
server app imagine it's a node app and

56
00:02:06,479 --> 00:02:10,259
we have a database doesn't matter which

57
00:02:08,280 --> 00:02:13,140
and we make some requests to the

58
00:02:10,259 --> 00:02:15,120
database to fetch some data right so

59
00:02:13,140 --> 00:02:17,340
let's say we have this query select

60
00:02:15,120 --> 00:02:19,319
everything from users we just want to

61
00:02:17,340 --> 00:02:21,840
get the user's data from the user State

62
00:02:19,319 --> 00:02:24,180
and now whenever we have a cache in

63
00:02:21,840 --> 00:02:26,879
between the cool thing about it is that

64
00:02:24,180 --> 00:02:29,400
you can retrieve the same data from the

65
00:02:26,879 --> 00:02:31,379
cache if it's if it exists in a cache

66
00:02:29,400 --> 00:02:33,540
meaning this extra request to the

67
00:02:31,379 --> 00:02:36,120
database is not needed anymore we can

68
00:02:33,540 --> 00:02:38,459
get the same data from the cache so as

69
00:02:36,120 --> 00:02:40,739
as you can see it obviously reduces the

70
00:02:38,459 --> 00:02:43,560
latency because we get rid of one extra

71
00:02:40,739 --> 00:02:46,160
request it doesn't it also reduces the

72
00:02:43,560 --> 00:02:49,080
load on the database because there is no

73
00:02:46,160 --> 00:02:52,080
querying of the database so database is

74
00:02:49,080 --> 00:02:54,780
just still running still and we also

75
00:02:52,080 --> 00:02:56,879
save on network cost because as you know

76
00:02:54,780 --> 00:02:58,920
if you are running an infrastructure

77
00:02:56,879 --> 00:03:01,980
which is big and serving millions of

78
00:02:58,920 --> 00:03:04,620
users every net Network request costs

79
00:03:01,980 --> 00:03:07,440
you money so let's talk about types of

80
00:03:04,620 --> 00:03:09,720
caches by a level because this is also

81
00:03:07,440 --> 00:03:12,420
quite interesting so we have client-side

82
00:03:09,720 --> 00:03:15,120
caching all right client-side caching is

83
00:03:12,420 --> 00:03:17,819
meant some it is meant to be for example

84
00:03:15,120 --> 00:03:20,040
like a your mobile app or or a web

85
00:03:17,819 --> 00:03:22,440
browser and I have an interesting video

86
00:03:20,040 --> 00:03:24,900
talking about that specifically HTTP

87
00:03:22,440 --> 00:03:27,300
caching so take a look at it if you want

88
00:03:24,900 --> 00:03:29,340
to learn about client-side caching it's

89
00:03:27,300 --> 00:03:31,860
also very important for web developers

90
00:03:29,340 --> 00:03:34,560
we also have CDN caching which kind of

91
00:03:31,860 --> 00:03:37,260
goes hand in hand because you're serving

92
00:03:34,560 --> 00:03:39,659
the assets from the CDN which is the

93
00:03:37,260 --> 00:03:41,340
best case scenario and I mean the static

94
00:03:39,659 --> 00:03:43,739
assets and we also have a web server

95
00:03:41,340 --> 00:03:46,019
caching you can also cache some requests

96
00:03:43,739 --> 00:03:49,080
on the web server level for example you

97
00:03:46,019 --> 00:03:52,440
make a request your node application and

98
00:03:49,080 --> 00:03:55,500
it Returns the data without even going

99
00:03:52,440 --> 00:03:58,019
to another cache it has its own cache

100
00:03:55,500 --> 00:03:59,760
like varnish and we also have a database

101
00:03:58,019 --> 00:04:03,480
caching because if you didn't know they

102
00:03:59,760 --> 00:04:06,540
databases like MySQL or have a

103
00:04:03,480 --> 00:04:09,060
built-in database caching and it doesn't

104
00:04:06,540 --> 00:04:11,760
perform that well that's why we always

105
00:04:09,060 --> 00:04:13,620
need something extra like an application

106
00:04:11,760 --> 00:04:15,780
caching so in this video application

107
00:04:13,620 --> 00:04:18,299
caching is what we're going to focus on

108
00:04:15,780 --> 00:04:20,340
and it is actually the thing that

109
00:04:18,299 --> 00:04:22,260
concerns us the most as developers

110
00:04:20,340 --> 00:04:25,199
because it's the most important layer

111
00:04:22,260 --> 00:04:27,360
and most important and most powerful

112
00:04:25,199 --> 00:04:30,419
layer of caching for us so let's also

113
00:04:27,360 --> 00:04:32,340
talk about types of caches by Design we

114
00:04:30,419 --> 00:04:34,380
have a global cache let's imagine we

115
00:04:32,340 --> 00:04:36,840
have an application cluster so we have

116
00:04:34,380 --> 00:04:39,060
three nodes of node.js servers and we

117
00:04:36,840 --> 00:04:42,300
have one shared cache which communicates

118
00:04:39,060 --> 00:04:45,000
with us so with the servers and with the

119
00:04:42,300 --> 00:04:47,460
database aka the storage but we also

120
00:04:45,000 --> 00:04:49,919
have a different schema here where every

121
00:04:47,460 --> 00:04:53,580
microservice can communicate to

122
00:04:49,919 --> 00:04:56,220
different node or Cache node and this is

123
00:04:53,580 --> 00:04:58,860
called a distributed cache because let's

124
00:04:56,220 --> 00:05:01,500
say Node 1 would be the primary cache

125
00:04:58,860 --> 00:05:04,560
and node 2 and 3 would be the replicas

126
00:05:01,500 --> 00:05:07,080
so this basically allows you to

127
00:05:04,560 --> 00:05:09,240
um to optimize your architecture by

128
00:05:07,080 --> 00:05:12,060
having multiple nodes of caching so

129
00:05:09,240 --> 00:05:13,680
going back you don't rely only on one

130
00:05:12,060 --> 00:05:16,080
instance of the shared cache but

131
00:05:13,680 --> 00:05:18,240
multiple with this obviously makes your

132
00:05:16,080 --> 00:05:21,120
system faster but it comes with an extra

133
00:05:18,240 --> 00:05:23,880
overhead like syncing the replica nodes

134
00:05:21,120 --> 00:05:27,060
2 and 3 with the Node 1 which is the

135
00:05:23,880 --> 00:05:29,160
primary and as you can see down below it

136
00:05:27,060 --> 00:05:31,560
says a cash cluster so this is what we

137
00:05:29,160 --> 00:05:36,720
call a cash class a typical architecture

138
00:05:31,560 --> 00:05:38,520
on an AWS site because AWS is the cloud

139
00:05:36,720 --> 00:05:40,500
provider that I've used the most and I

140
00:05:38,520 --> 00:05:42,660
think YouTube would look something like

141
00:05:40,500 --> 00:05:44,759
this so we have a load balancer

142
00:05:42,660 --> 00:05:47,520
obviously by the way I also have a video

143
00:05:44,759 --> 00:05:49,979
on load balancers which goes deep into

144
00:05:47,520 --> 00:05:52,199
them and talks about what algorithms

145
00:05:49,979 --> 00:05:54,060
load balancers use so check it out if

146
00:05:52,199 --> 00:05:55,919
you're interested but we also have an

147
00:05:54,060 --> 00:05:58,919
auto scaling Group which is let's say

148
00:05:55,919 --> 00:06:01,199
ec2 instances those are just servers and

149
00:05:58,919 --> 00:06:03,660
they are have having their communicating

150
00:06:01,199 --> 00:06:05,820
with an extra layer called elastic cache

151
00:06:03,660 --> 00:06:07,740
cluster so this is the caching cluster

152
00:06:05,820 --> 00:06:10,560
that we talked about as you can see on

153
00:06:07,740 --> 00:06:12,600
the right we have a radius primary cache

154
00:06:10,560 --> 00:06:15,240
and on the red the left we have a read

155
00:06:12,600 --> 00:06:17,880
replica which communicates with the

156
00:06:15,240 --> 00:06:20,220
primary uh which can communicate with a

157
00:06:17,880 --> 00:06:22,259
standby database or the primary database

158
00:06:20,220 --> 00:06:24,060
because you can also have replicas not

159
00:06:22,259 --> 00:06:26,520
only on the cache level but also on the

160
00:06:24,060 --> 00:06:29,220
data so caching strategies and

161
00:06:26,520 --> 00:06:31,800
invalidation as we said in validation is

162
00:06:29,220 --> 00:06:34,800
very important but for that we also need

163
00:06:31,800 --> 00:06:36,300
to know about strategies of how we cache

164
00:06:34,800 --> 00:06:38,759
things so first of all let's talk about

165
00:06:36,300 --> 00:06:41,639
the right around cache which is the

166
00:06:38,759 --> 00:06:43,259
quite popular one one of the two most

167
00:06:41,639 --> 00:06:46,319
popular strategies it's also called

168
00:06:43,259 --> 00:06:48,300
cache aside or laser loading and I'm

169
00:06:46,319 --> 00:06:50,520
gonna explain why so let's take a look

170
00:06:48,300 --> 00:06:54,060
at the client here right the client

171
00:06:50,520 --> 00:06:55,860
makes a request to the storage and gets

172
00:06:54,060 --> 00:06:57,960
the data but with the cache what we're

173
00:06:55,860 --> 00:07:00,180
gonna do in this case is first of all

174
00:06:57,960 --> 00:07:02,280
instead of making a request to to the

175
00:07:00,180 --> 00:07:04,680
storage well in client in this case is

176
00:07:02,280 --> 00:07:07,500
is a web server right in this scenario

177
00:07:04,680 --> 00:07:09,539
it is a client so what we're gonna do is

178
00:07:07,500 --> 00:07:12,240
first try to read the data from the

179
00:07:09,539 --> 00:07:13,860
cache if it if the data is in the cache

180
00:07:12,240 --> 00:07:16,380
where you turn it to the client and

181
00:07:13,860 --> 00:07:18,360
everything's good if the if we read the

182
00:07:16,380 --> 00:07:21,060
try to read the data from the cache and

183
00:07:18,360 --> 00:07:23,400
the data is not in the cache then the

184
00:07:21,060 --> 00:07:26,039
cache tells us that hey it's empty then

185
00:07:23,400 --> 00:07:28,319
we know that we need to make a request

186
00:07:26,039 --> 00:07:31,319
to the storage and get it from there

187
00:07:28,319 --> 00:07:33,180
okay and every time so how do you

188
00:07:31,319 --> 00:07:36,060
actually update the cache well every

189
00:07:33,180 --> 00:07:38,819
time we make a write request to the

190
00:07:36,060 --> 00:07:41,220
storage we know that we also need to

191
00:07:38,819 --> 00:07:43,560
update the cache so we do it at the same

192
00:07:41,220 --> 00:07:45,840
time all right so let's talk about this

193
00:07:43,560 --> 00:07:48,180
it's called a reactive approach first of

194
00:07:45,840 --> 00:07:51,000
all so the good thing about that is that

195
00:07:48,180 --> 00:07:53,099
the cache stays slim and only contains

196
00:07:51,000 --> 00:07:55,680
data that it really needs meaning that

197
00:07:53,099 --> 00:07:58,560
you update the cache only when you

198
00:07:55,680 --> 00:08:00,539
update the database so you don't always

199
00:07:58,560 --> 00:08:02,759
update the cache and and it's quite

200
00:08:00,539 --> 00:08:06,060
straightforward in implementation and

201
00:08:02,759 --> 00:08:08,639
it's it's pretty much used by default by

202
00:08:06,060 --> 00:08:11,220
most caching providers the cons the con

203
00:08:08,639 --> 00:08:13,740
is that cache gets filled only after a

204
00:08:11,220 --> 00:08:16,259
cache Miss meaning three three trips

205
00:08:13,740 --> 00:08:18,660
because you first need to request this

206
00:08:16,259 --> 00:08:21,060
data from the cache and after this cache

207
00:08:18,660 --> 00:08:22,740
says that the data is not there then you

208
00:08:21,060 --> 00:08:24,479
need to make a request to the database

209
00:08:22,740 --> 00:08:26,460
and then you need to make another

210
00:08:24,479 --> 00:08:28,680
request to the cache to update it right

211
00:08:26,460 --> 00:08:31,319
otherwise how does the data get into the

212
00:08:28,680 --> 00:08:33,479
cache well there is another caching

213
00:08:31,319 --> 00:08:35,219
strategy which is also very popular it's

214
00:08:33,479 --> 00:08:38,039
called Write through cache and as you

215
00:08:35,219 --> 00:08:40,440
can see the client makes a request wants

216
00:08:38,039 --> 00:08:42,659
to fetch the data and first we make a

217
00:08:40,440 --> 00:08:44,640
request to the cache if the data is in

218
00:08:42,659 --> 00:08:47,160
the cache we obviously return it if the

219
00:08:44,640 --> 00:08:49,560
data is not in the cache we write it to

220
00:08:47,160 --> 00:08:51,959
the storage but the cool thing here is

221
00:08:49,560 --> 00:08:54,720
that if the data is not in the cache it

222
00:08:51,959 --> 00:08:57,360
automatically gets updated on the way so

223
00:08:54,720 --> 00:08:59,040
it sits right in the middle and it

224
00:08:57,360 --> 00:09:01,800
doesn't matter if it's in the cache or

225
00:08:59,040 --> 00:09:04,200
not as soon as we make a write request

226
00:09:01,800 --> 00:09:07,620
meaning updating the database the cache

227
00:09:04,200 --> 00:09:09,899
also gets updated and this is pretty

228
00:09:07,620 --> 00:09:12,779
cool because it first of all it's called

229
00:09:09,899 --> 00:09:16,200
a proactive approach because we do it on

230
00:09:12,779 --> 00:09:18,420
our own like actively updating the cache

231
00:09:16,200 --> 00:09:20,880
instead of asking the database for the

232
00:09:18,420 --> 00:09:22,380
data and then updating the cache so the

233
00:09:20,880 --> 00:09:24,240
good thing about is that it's well

234
00:09:22,380 --> 00:09:26,640
synced with a database resulting in

235
00:09:24,240 --> 00:09:28,920
fewer reads of the database obviously

236
00:09:26,640 --> 00:09:31,200
because we update the cash cache quite

237
00:09:28,920 --> 00:09:33,600
often meaning every time we write and

238
00:09:31,200 --> 00:09:36,360
the downside is that the infrequently

239
00:09:33,600 --> 00:09:39,300
requested data is also written to the

240
00:09:36,360 --> 00:09:41,459
cache so why is it a problem first of

241
00:09:39,300 --> 00:09:44,220
all it's going to result in a bigger

242
00:09:41,459 --> 00:09:45,899
cache and it's going to get filled with

243
00:09:44,220 --> 00:09:48,060
data that we don't really need to store

244
00:09:45,899 --> 00:09:50,100
in the cache and caches are usual

245
00:09:48,060 --> 00:09:52,320
application caches are usually stored in

246
00:09:50,100 --> 00:09:55,019
the memory so in the ram random access

247
00:09:52,320 --> 00:09:57,360
memory so as you can imagine they are

248
00:09:55,019 --> 00:09:59,820
not that big as the disk space to be

249
00:09:57,360 --> 00:10:02,160
able to store such large amounts of of

250
00:09:59,820 --> 00:10:03,959
information and you would normally

251
00:10:02,160 --> 00:10:06,360
Implement caching when you have

252
00:10:03,959 --> 00:10:08,519
repeating requests let's say you have

253
00:10:06,360 --> 00:10:11,580
Instagram and Instagram has a lot of

254
00:10:08,519 --> 00:10:14,279
user profiles right but 99 of those

255
00:10:11,580 --> 00:10:16,920
profiles don't get queried that often

256
00:10:14,279 --> 00:10:18,720
compared to celebrities accounts let's

257
00:10:16,920 --> 00:10:20,940
say Justin Bieber Justin Bieber's

258
00:10:18,720 --> 00:10:23,399
account gets queried pretty much every

259
00:10:20,940 --> 00:10:25,260
second so it would make sense to Cache

260
00:10:23,399 --> 00:10:27,360
his account for users that are

261
00:10:25,260 --> 00:10:29,760
requesting his account compared to my

262
00:10:27,360 --> 00:10:32,339
account which gets requested let's say

263
00:10:29,760 --> 00:10:35,040
once a week or so so if you were

264
00:10:32,339 --> 00:10:37,440
implementing a cache through algorithm

265
00:10:35,040 --> 00:10:39,060
my account is also going to end up in

266
00:10:37,440 --> 00:10:41,160
the cache which is not good we don't

267
00:10:39,060 --> 00:10:43,200
need that so that's the downside of the

268
00:10:41,160 --> 00:10:45,839
right through cache but we also have a

269
00:10:43,200 --> 00:10:48,860
write back cache what it is is basically

270
00:10:45,839 --> 00:10:51,660
gives it just simply gives us in

271
00:10:48,860 --> 00:10:53,940
asynchronicity asynchronicity yeah I

272
00:10:51,660 --> 00:10:56,220
think I spelled this word right so we're

273
00:10:53,940 --> 00:10:58,440
going to deal with the cache just like

274
00:10:56,220 --> 00:11:01,620
in the right through cash but the

275
00:10:58,440 --> 00:11:04,200
writing to the database is is performed

276
00:11:01,620 --> 00:11:06,480
asynchronously so we are having some

277
00:11:04,200 --> 00:11:08,760
delay here first of all the downside is

278
00:11:06,480 --> 00:11:11,579
that the cache and the storage meaning

279
00:11:08,760 --> 00:11:13,680
the database can get out of sync somehow

280
00:11:11,579 --> 00:11:15,540
if we have multiple nodes and it's

281
00:11:13,680 --> 00:11:17,519
difficult to manage it well these kind

282
00:11:15,540 --> 00:11:19,440
of strategies are not enough

283
00:11:17,519 --> 00:11:21,839
unfortunately because there are some

284
00:11:19,440 --> 00:11:24,420
edge cases that are not covered in in

285
00:11:21,839 --> 00:11:26,519
here first of all let's say we are

286
00:11:24,420 --> 00:11:28,740
asking for the user one two three which

287
00:11:26,519 --> 00:11:31,320
is Justin Bieber from the cache and the

288
00:11:28,740 --> 00:11:33,540
the cache gives us this data right

289
00:11:31,320 --> 00:11:36,060
everything's cool but what if we have

290
00:11:33,540 --> 00:11:38,940
another server app which updates the

291
00:11:36,060 --> 00:11:41,579
database without talking to our cache so

292
00:11:38,940 --> 00:11:44,399
it updates the database from the side

293
00:11:41,579 --> 00:11:46,560
and our cache does not know that the

294
00:11:44,399 --> 00:11:49,980
database has been updated so it updates

295
00:11:46,560 --> 00:11:52,079
the user123 it changes its value to JB

296
00:11:49,980 --> 00:11:55,380
like the initials of Justin Bieber but

297
00:11:52,079 --> 00:11:58,260
our cache still stored this data for the

298
00:11:55,380 --> 00:12:01,200
user123 as Justin Bieber so every time

299
00:11:58,260 --> 00:12:03,779
our server first server app this one

300
00:12:01,200 --> 00:12:06,300
makes a request wants to get the data

301
00:12:03,779 --> 00:12:08,640
for user123 it's going to get the stale

302
00:12:06,300 --> 00:12:11,640
data right and we also have another use

303
00:12:08,640 --> 00:12:13,380
case when cache just goes down for one

304
00:12:11,640 --> 00:12:16,019
or two seconds let's say there was an

305
00:12:13,380 --> 00:12:18,180
error and it's restarting so this can

306
00:12:16,019 --> 00:12:21,600
also lead to inconsistencies because

307
00:12:18,180 --> 00:12:23,700
we're going to update the user123 as JB

308
00:12:21,600 --> 00:12:25,740
the cache is not going to see that the

309
00:12:23,700 --> 00:12:28,320
database is going to get updated and the

310
00:12:25,740 --> 00:12:30,839
cache as still still has the stale value

311
00:12:28,320 --> 00:12:32,760
when it it's up and running again right

312
00:12:30,839 --> 00:12:35,640
that's not good we're going to take a

313
00:12:32,760 --> 00:12:37,800
look at that and add some mitigation

314
00:12:35,640 --> 00:12:39,600
strategies but first of all let's talk

315
00:12:37,800 --> 00:12:42,540
about eviction policies which is

316
00:12:39,600 --> 00:12:45,180
important to keep our cache and database

317
00:12:42,540 --> 00:12:47,579
in sync so first of all how do you get

318
00:12:45,180 --> 00:12:49,440
rid of the stale data in your database

319
00:12:47,579 --> 00:12:53,940
well there's an algorithm for it called

320
00:12:49,440 --> 00:12:56,220
list list recently used or lru Cache

321
00:12:53,940 --> 00:12:58,500
it's very famous for example in your

322
00:12:56,220 --> 00:13:00,360
mobile phones whenever you open multiple

323
00:12:58,500 --> 00:13:02,639
applications let's say you open 20

324
00:13:00,360 --> 00:13:06,180
applications but obviously your phone's

325
00:13:02,639 --> 00:13:08,279
Ram cannot keep 20 applications like in

326
00:13:06,180 --> 00:13:10,380
the active state so it's going to put

327
00:13:08,279 --> 00:13:12,120
them in like a sleeping state but how

328
00:13:10,380 --> 00:13:14,880
does it know which ones to put there

329
00:13:12,120 --> 00:13:16,860
it's going to put the least recently

330
00:13:14,880 --> 00:13:19,860
used ones there so the ones that you

331
00:13:16,860 --> 00:13:21,540
open the first and didn't use for half a

332
00:13:19,860 --> 00:13:24,899
day for example so let's say we have

333
00:13:21,540 --> 00:13:27,300
three entities in our cache username one

334
00:13:24,899 --> 00:13:30,560
with 10 hits let's say within an hour

335
00:13:27,300 --> 00:13:33,779
username two with 16 hits using M3 with

336
00:13:30,560 --> 00:13:35,579
155 hits you can take these usernames AS

337
00:13:33,779 --> 00:13:37,560
application names if you were talking

338
00:13:35,579 --> 00:13:40,740
about your smartphone all right and then

339
00:13:37,560 --> 00:13:43,079
what lru does it simply rearranges them

340
00:13:40,740 --> 00:13:45,120
so username is gonna get to the first

341
00:13:43,079 --> 00:13:47,279
place username two is going to be on the

342
00:13:45,120 --> 00:13:50,279
second place and username one with a

343
00:13:47,279 --> 00:13:52,500
list hits becomes an a candidate for

344
00:13:50,279 --> 00:13:54,899
eviction and as soon as we have a new

345
00:13:52,500 --> 00:13:57,660
username let's say username four with

346
00:13:54,899 --> 00:13:59,700
let's say 11 hits username one gets

347
00:13:57,660 --> 00:14:01,980
kicked out from the cache the this is

348
00:13:59,700 --> 00:14:03,839
how the lru cache works we also have

349
00:14:01,980 --> 00:14:06,420
some other algorithms like least

350
00:14:03,839 --> 00:14:09,180
frequently used cash so least recently

351
00:14:06,420 --> 00:14:11,399
used cash is going to work within a like

352
00:14:09,180 --> 00:14:14,459
a specific time frame while least

353
00:14:11,399 --> 00:14:17,579
frequently used cash is going to have a

354
00:14:14,459 --> 00:14:20,760
specific count for for the usage and we

355
00:14:17,579 --> 00:14:22,800
also have lasting first Out means the

356
00:14:20,760 --> 00:14:25,680
new application or the new username

357
00:14:22,800 --> 00:14:27,779
comes in the first one the old one goes

358
00:14:25,680 --> 00:14:29,940
out immediately and we have random

359
00:14:27,779 --> 00:14:32,639
replacement meaning if we have a new

360
00:14:29,940 --> 00:14:35,700
entity in our cache we select one random

361
00:14:32,639 --> 00:14:38,700
entity and delete one of them which is

362
00:14:35,700 --> 00:14:40,920
not so optimal in the case of users so

363
00:14:38,700 --> 00:14:43,560
we also have we still have this problem

364
00:14:40,920 --> 00:14:47,220
right what if the cache goes down and we

365
00:14:43,560 --> 00:14:49,199
update our database and it still and the

366
00:14:47,220 --> 00:14:51,720
cache when whenever the cache is on

367
00:14:49,199 --> 00:14:53,760
again it still serves us sale data

368
00:14:51,720 --> 00:14:55,620
because at least recently used cash does

369
00:14:53,760 --> 00:14:57,480
not help us in this case well there are

370
00:14:55,620 --> 00:14:59,820
some strategies first of all you can set

371
00:14:57,480 --> 00:15:02,399
a time to live to eventually itself

372
00:14:59,820 --> 00:15:04,320
clean up your cash so let's say your

373
00:15:02,399 --> 00:15:06,839
time to live for your cash is one day

374
00:15:04,320 --> 00:15:08,940
meaning that every entity that has been

375
00:15:06,839 --> 00:15:11,279
added to your cash gets automatically

376
00:15:08,940 --> 00:15:13,440
removed by midnight this is going to

377
00:15:11,279 --> 00:15:16,019
make sure that your cache is up to date

378
00:15:13,440 --> 00:15:19,079
and fresh all the time we also have a

379
00:15:16,019 --> 00:15:21,600
laser read repair meaning that we can

380
00:15:19,079 --> 00:15:23,699
set such a strategy that every time we

381
00:15:21,600 --> 00:15:25,980
read from the database for example in

382
00:15:23,699 --> 00:15:28,620
the in the case of a set aside cache we

383
00:15:25,980 --> 00:15:30,720
randomly pick requests that are even

384
00:15:28,620 --> 00:15:32,459
even if it's still in the cache we're

385
00:15:30,720 --> 00:15:35,100
still going to read it from the database

386
00:15:32,459 --> 00:15:37,620
as well and update the cache and this is

387
00:15:35,100 --> 00:15:40,199
done like random and we also have some

388
00:15:37,620 --> 00:15:42,360
background processes if you're using

389
00:15:40,199 --> 00:15:44,699
radius for example you can use the scan

390
00:15:42,360 --> 00:15:47,100
operation which is going to work as a

391
00:15:44,699 --> 00:15:49,980
Cron job in your background and sync

392
00:15:47,100 --> 00:15:52,139
items with your cache between your cache

393
00:15:49,980 --> 00:15:54,120
and the database and now let's take a

394
00:15:52,139 --> 00:15:56,699
look at the implementation as I told you

395
00:15:54,120 --> 00:15:59,040
so we can have a node.js application

396
00:15:56,699 --> 00:16:02,100
like this so it's basically an Express

397
00:15:59,040 --> 00:16:04,320
app which uses axio and redis and it's

398
00:16:02,100 --> 00:16:06,959
pretty straightforward we set up the

399
00:16:04,320 --> 00:16:09,420
redis here so we're connecting to rated

400
00:16:06,959 --> 00:16:11,699
server on this port here we have the

401
00:16:09,420 --> 00:16:14,399
redis client assigned here some error

402
00:16:11,699 --> 00:16:17,820
handling okay and we connect to redis

403
00:16:14,399 --> 00:16:20,279
and we have one route so we are going to

404
00:16:17,820 --> 00:16:22,260
fetch some to-do's from the to-doos API

405
00:16:20,279 --> 00:16:24,420
and what you can pass here is basically

406
00:16:22,260 --> 00:16:26,760
an ID for it to do and it's going to

407
00:16:24,420 --> 00:16:28,860
call this controller you get to do data

408
00:16:26,760 --> 00:16:31,380
this controller basically takes takes

409
00:16:28,860 --> 00:16:34,800
the to-do ID and we also have this cache

410
00:16:31,380 --> 00:16:36,839
or this flag is cached or not just to be

411
00:16:34,800 --> 00:16:39,420
able to see if this is coming from the

412
00:16:36,839 --> 00:16:41,699
cache or not and we're going to have a

413
00:16:39,420 --> 00:16:43,860
try and catch so we're going to First

414
00:16:41,699 --> 00:16:46,320
Imagine This is a set aside because by

415
00:16:43,860 --> 00:16:48,899
default redis uses a set aside caching

416
00:16:46,320 --> 00:16:51,660
strategy so we're going to ask the cache

417
00:16:48,899 --> 00:16:54,420
if it has a data for this ID if it does

418
00:16:51,660 --> 00:16:57,180
have then we parse it and we are going

419
00:16:54,420 --> 00:16:59,399
to return it for here and of course we

420
00:16:57,180 --> 00:17:00,899
are going to say is cached meaning think

421
00:16:59,399 --> 00:17:02,339
that we're returning it from the cache

422
00:17:00,899 --> 00:17:04,140
so from the cache is going to be true

423
00:17:02,339 --> 00:17:06,059
otherwise we don't have it in account

424
00:17:04,140 --> 00:17:08,760
right then we have to make an actual

425
00:17:06,059 --> 00:17:11,100
request of the API and then we are also

426
00:17:08,760 --> 00:17:13,620
going to update our cache because it's a

427
00:17:11,100 --> 00:17:16,260
set aside cache and we're going to call

428
00:17:13,620 --> 00:17:19,140
this Json stringify to turn the result

429
00:17:16,260 --> 00:17:21,360
into a string because redis works with

430
00:17:19,140 --> 00:17:24,660
key value pairs where value is a string

431
00:17:21,360 --> 00:17:26,699
all right and this is our fetch API data

432
00:17:24,660 --> 00:17:28,679
which is being called here in case if

433
00:17:26,699 --> 00:17:30,179
the data is not in the cache and we are

434
00:17:28,679 --> 00:17:32,880
simply going to call this Json

435
00:17:30,179 --> 00:17:35,220
placeholder and get the to-do ID all

436
00:17:32,880 --> 00:17:36,539
right very simple so let's let's see how

437
00:17:35,220 --> 00:17:40,080
it's going to work I have three

438
00:17:36,539 --> 00:17:42,299
Terminals and in this terminal I have a

439
00:17:40,080 --> 00:17:45,360
radius instance running so it's a Docker

440
00:17:42,299 --> 00:17:48,179
image running a redis server and I'm

441
00:17:45,360 --> 00:17:50,880
actually going to run it again I think

442
00:17:48,179 --> 00:17:54,000
yep like this so ready to accept

443
00:17:50,880 --> 00:17:56,100
connections so our Docker image or

444
00:17:54,000 --> 00:17:58,860
container for redis is running and here

445
00:17:56,100 --> 00:18:01,200
I would like to start the server so I'm

446
00:17:58,860 --> 00:18:03,000
going to oh by the way let me show you

447
00:18:01,200 --> 00:18:05,220
the file structure I simply have an

448
00:18:03,000 --> 00:18:07,320
index.js and then package.json what I

449
00:18:05,220 --> 00:18:09,840
have here is as I told you axios express

450
00:18:07,320 --> 00:18:12,419
and red is installed and nothing else

451
00:18:09,840 --> 00:18:16,200
and of course the type module so that I

452
00:18:12,419 --> 00:18:19,140
can use Imports like this so let's start

453
00:18:16,200 --> 00:18:21,780
the application I'm gonna write node

454
00:18:19,140 --> 00:18:25,140
index.js and app is listening on Port

455
00:18:21,780 --> 00:18:29,100
3000 so what do I what we're gonna do is

456
00:18:25,140 --> 00:18:31,860
we're going to call this URL with a curl

457
00:18:29,100 --> 00:18:35,700
let's say I want to pass a different ID

458
00:18:31,860 --> 00:18:39,059
I want to pass id42 so let's see what we

459
00:18:35,700 --> 00:18:42,059
got back so from cash fold because we

460
00:18:39,059 --> 00:18:44,160
literally went to the API because it the

461
00:18:42,059 --> 00:18:47,400
data was not in a cache so as it says

462
00:18:44,160 --> 00:18:50,400
request sent to the API and this is the

463
00:18:47,400 --> 00:18:53,580
data that we got here user ID word three

464
00:18:50,400 --> 00:18:56,160
id42 title blah blah blah so why don't

465
00:18:53,580 --> 00:18:58,440
we call it again let's call it again

466
00:18:56,160 --> 00:19:01,140
from Cache true and on the second try

467
00:18:58,440 --> 00:19:03,299
let's call it again third try fourth try

468
00:19:01,140 --> 00:19:05,520
we are now getting it from the cache

469
00:19:03,299 --> 00:19:07,679
because the first time it wasn't on the

470
00:19:05,520 --> 00:19:09,840
cache and we added it to our cache here

471
00:19:07,679 --> 00:19:11,820
so we set it to the cache in the cache

472
00:19:09,840 --> 00:19:13,620
and now all the subsequent requests are

473
00:19:11,820 --> 00:19:15,840
coming from the cat now we talked about

474
00:19:13,620 --> 00:19:18,179
eviction policies and time to leave

475
00:19:15,840 --> 00:19:21,780
right to live and redis gives us this

476
00:19:18,179 --> 00:19:24,780
option to specify uh these options so

477
00:19:21,780 --> 00:19:27,960
first of all we're going to say e x and

478
00:19:24,780 --> 00:19:29,940
this is the time in seconds that you can

479
00:19:27,960 --> 00:19:34,080
assign for every item to live for

480
00:19:29,940 --> 00:19:37,140
example I would say let's say 1000 no I

481
00:19:34,080 --> 00:19:39,600
would say I would say just 120 so two

482
00:19:37,140 --> 00:19:42,539
minutes to live and you also have

483
00:19:39,600 --> 00:19:45,059
another option called NX which is a

484
00:19:42,539 --> 00:19:48,360
Boolean and it tells the red is that

485
00:19:45,059 --> 00:19:49,919
only update the cache if the key is not

486
00:19:48,360 --> 00:19:52,380
there so if we have the key don't

487
00:19:49,919 --> 00:19:54,900
override it only update it if we don't

488
00:19:52,380 --> 00:19:57,960
have all right so another cool thing

489
00:19:54,900 --> 00:20:00,960
that we have here is the red CLI so

490
00:19:57,960 --> 00:20:03,840
let's run it I think I need npx for this

491
00:20:00,960 --> 00:20:06,419
so let me do like this and I connect it

492
00:20:03,840 --> 00:20:08,460
to the radius server right and now I can

493
00:20:06,419 --> 00:20:12,000
do I can basically check what's inside

494
00:20:08,460 --> 00:20:15,660
my cache so I'm gonna do get 42 and 42

495
00:20:12,000 --> 00:20:18,900
is simply the ID because in here on line

496
00:20:15,660 --> 00:20:21,960
38 Ready Set is basically a key and

497
00:20:18,900 --> 00:20:24,179
value pair so the key was the ID that I

498
00:20:21,960 --> 00:20:27,120
basically called before and I do get 42

499
00:20:24,179 --> 00:20:29,640
and it gives me the string that it has

500
00:20:27,120 --> 00:20:32,760
saved and if I delete it again without

501
00:20:29,640 --> 00:20:35,340
waiting for the deletion policy

502
00:20:32,760 --> 00:20:37,740
um as soon as I make another request let

503
00:20:35,340 --> 00:20:39,720
me first exit it and I'm going to curl

504
00:20:37,740 --> 00:20:41,940
it again as you can see again it's not

505
00:20:39,720 --> 00:20:43,919
in the cache because it got deleted and

506
00:20:41,940 --> 00:20:47,100
let's call it again and now it is in a

507
00:20:43,919 --> 00:20:49,679
cache so this is how a simple example of

508
00:20:47,100 --> 00:20:52,020
a redis cache would work obviously in

509
00:20:49,679 --> 00:20:54,539
complex architectures you would have

510
00:20:52,020 --> 00:20:57,059
multiple instances of this cache and you

511
00:20:54,539 --> 00:20:58,740
have replicas and so so as you saw it's

512
00:20:57,059 --> 00:21:01,140
very easy to implement caching when it

513
00:20:58,740 --> 00:21:03,120
come comes to the code existing

514
00:21:01,140 --> 00:21:05,460
Solutions work very well especially

515
00:21:03,120 --> 00:21:07,919
redis which I would really recommend but

516
00:21:05,460 --> 00:21:10,919
you also have memcache we have varnish

517
00:21:07,919 --> 00:21:13,020
which is a web web server level cache

518
00:21:10,919 --> 00:21:15,660
you also have node cache which is also

519
00:21:13,020 --> 00:21:17,880
an in-memory cache specifically for node

520
00:21:15,660 --> 00:21:21,360
but obviously it doesn't have that many

521
00:21:17,880 --> 00:21:23,580
features as redis and last but piece

522
00:21:21,360 --> 00:21:25,679
let's talk about when you shouldn't use

523
00:21:23,580 --> 00:21:28,260
a cat first of all if you added the

524
00:21:25,679 --> 00:21:29,940
cache and you see no differences between

525
00:21:28,260 --> 00:21:32,100
when you have a cache and you don't have

526
00:21:29,940 --> 00:21:34,080
a cache you probably don't need a cache

527
00:21:32,100 --> 00:21:36,299
because you don't need this extra layer

528
00:21:34,080 --> 00:21:38,460
right obviously and the second thing is

529
00:21:36,299 --> 00:21:40,679
when you have higher randomness of

530
00:21:38,460 --> 00:21:42,780
requests let's say it's not an Instagram

531
00:21:40,679 --> 00:21:45,780
application where you have determined

532
00:21:42,780 --> 00:21:48,720
user profiles but you have some kind of

533
00:21:45,780 --> 00:21:51,059
a live stream with random comments right

534
00:21:48,720 --> 00:21:53,100
you can have so many comments on the

535
00:21:51,059 --> 00:21:55,260
live stream and they're all random and

536
00:21:53,100 --> 00:21:57,539
you don't know which comment can be

537
00:21:55,260 --> 00:21:59,640
accessed if somebody wants to answer to

538
00:21:57,539 --> 00:22:02,880
this comment which comment can be access

539
00:21:59,640 --> 00:22:05,880
more frequently than other so if you can

540
00:22:02,880 --> 00:22:08,100
determine which entity should probably

541
00:22:05,880 --> 00:22:09,780
be cached or not it means your date is

542
00:22:08,100 --> 00:22:12,900
random and you shouldn't catch anything

543
00:22:09,780 --> 00:22:15,179
and as again I have a typo here but

544
00:22:12,900 --> 00:22:17,880
frequently updated data for example like

545
00:22:15,179 --> 00:22:19,620
a comments from the stream don't need to

546
00:22:17,880 --> 00:22:22,620
be updated because that's going to be

547
00:22:19,620 --> 00:22:24,780
too much overhead to keep keep your

548
00:22:22,620 --> 00:22:27,600
cache and your database in sync all

549
00:22:24,780 --> 00:22:29,100
right so this was it I hope I covered

550
00:22:27,600 --> 00:22:31,500
everything if you still have any

551
00:22:29,100 --> 00:22:33,360
questions please let me know Down Below

552
00:22:31,500 --> 00:22:35,700
in the comments and make sure you

553
00:22:33,360 --> 00:22:37,679
subscribe to the channel to be able to

554
00:22:35,700 --> 00:22:39,900
see more videos like this when they're

555
00:22:37,679 --> 00:22:42,799
coming out thank you very much and see

556
00:22:39,900 --> 00:22:42,799
you in the next one
```