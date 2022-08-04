```srt
1
00:00:00,399 --> 00:00:02,320
the broadcast is now starting all

2
00:00:02,320 --> 00:00:05,200
attendees are in listen only mode

3
00:00:05,200 --> 00:00:07,759
hello everyone and welcome to the snow

4
00:00:07,759 --> 00:00:09,360
software and itam

5
00:00:09,360 --> 00:00:11,440
webinar today we're going to be talking

6
00:00:11,440 --> 00:00:12,960
about java se8

7
00:00:12,960 --> 00:00:16,640
as you can see from the screen a few

8
00:00:16,640 --> 00:00:18,400
announcements here as as how we're going

9
00:00:18,400 --> 00:00:20,400
to run this presentation for you

10
00:00:20,400 --> 00:00:22,560
your lines are going to be muted and

11
00:00:22,560 --> 00:00:24,160
remain muted

12
00:00:24,160 --> 00:00:26,000
to ask questions though they are most

13
00:00:26,000 --> 00:00:27,279
welcome and we're going to have a

14
00:00:27,279 --> 00:00:29,679
question and answer period at the end

15
00:00:29,679 --> 00:00:31,519
there's a spot on your go to webinar

16
00:00:31,519 --> 00:00:33,600
control panel that says type message

17
00:00:33,600 --> 00:00:34,239
here

18
00:00:34,239 --> 00:00:36,559
you are welcome to do that at any point

19
00:00:36,559 --> 00:00:37,840
in in the

20
00:00:37,840 --> 00:00:40,480
uh presentation when we reach the end of

21
00:00:40,480 --> 00:00:42,320
the presentation then we will go through

22
00:00:42,320 --> 00:00:43,680
those questions

23
00:00:43,680 --> 00:00:45,360
if there's more questions that can be

24
00:00:45,360 --> 00:00:47,120
answered during the session

25
00:00:47,120 --> 00:00:49,600
we will go ahead and follow up with

26
00:00:49,600 --> 00:00:50,399
answers

27
00:00:50,399 --> 00:00:52,559
following the presentation by our

28
00:00:52,559 --> 00:00:53,520
speakers

29
00:00:53,520 --> 00:00:55,840
our speakers today are kristen bohr

30
00:00:55,840 --> 00:00:57,760
director product management of snow

31
00:00:57,760 --> 00:01:00,640
software and sarah robette product

32
00:01:00,640 --> 00:01:02,320
marketing manager at snow

33
00:01:02,320 --> 00:01:04,879
software and with that i'm going to turn

34
00:01:04,879 --> 00:01:08,320
it over to sarah thank you sarah

35
00:01:08,320 --> 00:01:11,040
thank you jenny well good morning good

36
00:01:11,040 --> 00:01:12,159
afternoon everyone

37
00:01:12,159 --> 00:01:15,280
um welcome to our short webinar where we

38
00:01:15,280 --> 00:01:16,080
will be taking

39
00:01:16,080 --> 00:01:17,680
well sorry i will be talking about the

40
00:01:17,680 --> 00:01:19,680
effects of oracle's announcement that

41
00:01:19,680 --> 00:01:21,680
from january 2019

42
00:01:21,680 --> 00:01:24,240
java se8 public updates will no longer

43
00:01:24,240 --> 00:01:26,320
be available for business commercial or

44
00:01:26,320 --> 00:01:27,439
production use

45
00:01:27,439 --> 00:01:30,079
without a commercial license although it

46
00:01:30,079 --> 00:01:30,720
will remain

47
00:01:30,720 --> 00:01:33,680
free for general purpose computing usage

48
00:01:33,680 --> 00:01:34,079
so

49
00:01:34,079 --> 00:01:36,000
what does it mean and how are oracle

50
00:01:36,000 --> 00:01:37,280
customers affected

51
00:01:37,280 --> 00:01:38,880
and what do you need to do to find out

52
00:01:38,880 --> 00:01:41,360
about your java usage to understand what

53
00:01:41,360 --> 00:01:42,640
you should do

54
00:01:42,640 --> 00:01:44,560
so as ginny said my name is sarah avette

55
00:01:44,560 --> 00:01:46,159
and i'm joined by my colleague chris

56
00:01:46,159 --> 00:01:48,720
denber who was an oracle lms auditor in

57
00:01:48,720 --> 00:01:50,560
a previous existence so he's very well

58
00:01:50,560 --> 00:01:52,880
placed to share his insights with us

59
00:01:52,880 --> 00:01:55,600
our aim in this webinar is to help you

60
00:01:55,600 --> 00:01:57,360
understand this complex subject

61
00:01:57,360 --> 00:01:59,040
and give you pointers as to what you

62
00:01:59,040 --> 00:02:01,119
should do and look at and

63
00:02:01,119 --> 00:02:04,159
the options we see available to you

64
00:02:04,159 --> 00:02:06,079
as jenny mentioned there will be an

65
00:02:06,079 --> 00:02:08,000
opportunity to pose questions for us

66
00:02:08,000 --> 00:02:11,520
to answer at the end of the session

67
00:02:11,599 --> 00:02:14,879
so let's get started this is the agenda

68
00:02:14,879 --> 00:02:16,319
and these are the topics we'll cover

69
00:02:16,319 --> 00:02:18,239
today to start

70
00:02:18,239 --> 00:02:19,920
we'll take a look at how we arrived at

71
00:02:19,920 --> 00:02:22,000
this point in java's history

72
00:02:22,000 --> 00:02:24,080
how oracle define usage and customer

73
00:02:24,080 --> 00:02:25,360
types and

74
00:02:25,360 --> 00:02:27,200
how the commercial features also need to

75
00:02:27,200 --> 00:02:30,080
be considered when looking at java usage

76
00:02:30,080 --> 00:02:31,840
i'll then hand over to chris who will

77
00:02:31,840 --> 00:02:33,599
cover how support is changing

78
00:02:33,599 --> 00:02:35,760
and what customers should do to put them

79
00:02:35,760 --> 00:02:37,280
in the best possible position

80
00:02:37,280 --> 00:02:40,640
and how we at snoke can help

81
00:02:41,680 --> 00:02:44,560
so in a recent blog sharat chanda who is

82
00:02:44,560 --> 00:02:46,800
the senior director of java sc product

83
00:02:46,800 --> 00:02:48,480
management at oracle

84
00:02:48,480 --> 00:02:50,800
said oracle is keeping java free and

85
00:02:50,800 --> 00:02:52,640
open providing stability

86
00:02:52,640 --> 00:02:54,800
performance and security updates to the

87
00:02:54,800 --> 00:02:57,519
current version at no extra cost

88
00:02:57,519 --> 00:02:59,440
during this webinar we'd like to look at

89
00:02:59,440 --> 00:03:00,560
how oracle will

90
00:03:00,560 --> 00:03:02,640
deliver this given the announcement

91
00:03:02,640 --> 00:03:05,040
about no more public updates for java

92
00:03:05,040 --> 00:03:07,680
se8

93
00:03:08,800 --> 00:03:11,040
as we all know java is one of the most

94
00:03:11,040 --> 00:03:12,720
popular programming languages in the

95
00:03:12,720 --> 00:03:13,440
world

96
00:03:13,440 --> 00:03:15,840
with millions of java based applications

97
00:03:15,840 --> 00:03:16,879
created

98
00:03:16,879 --> 00:03:19,120
and many more applications that won't

99
00:03:19,120 --> 00:03:22,239
work without having java installed

100
00:03:22,239 --> 00:03:25,280
when some first released java in 1995

101
00:03:25,280 --> 00:03:27,440
it did so under a proprietary software

102
00:03:27,440 --> 00:03:29,840
license but in 2007

103
00:03:29,840 --> 00:03:32,159
sunrise licensed java under a general

104
00:03:32,159 --> 00:03:33,360
public license

105
00:03:33,360 --> 00:03:35,519
to make java free to all under an open

106
00:03:35,519 --> 00:03:38,000
source model

107
00:03:38,000 --> 00:03:41,040
oracle acquired java oops rather some in

108
00:03:41,040 --> 00:03:41,920
2010

109
00:03:41,920 --> 00:03:43,920
and part of the agreement was the oracle

110
00:03:43,920 --> 00:03:45,680
would continue to make java available

111
00:03:45,680 --> 00:03:47,200
free of charge under the open source

112
00:03:47,200 --> 00:03:48,159
model

113
00:03:48,159 --> 00:03:50,799
oracle has done this under its oracle

114
00:03:50,799 --> 00:03:53,040
binary code license agreement

115
00:03:53,040 --> 00:03:55,120
but this all started to get complicated

116
00:03:55,120 --> 00:03:57,040
when oracle started to create additional

117
00:03:57,040 --> 00:03:58,400
commercial features

118
00:03:58,400 --> 00:04:00,640
to run with java se but made them

119
00:04:00,640 --> 00:04:02,159
available as separately licensed

120
00:04:02,159 --> 00:04:03,120
products

121
00:04:03,120 --> 00:04:05,360
specifically java se advanced and java

122
00:04:05,360 --> 00:04:06,799
sc suite

123
00:04:06,799 --> 00:04:09,360
and then in 2014 oracle introduced a new

124
00:04:09,360 --> 00:04:10,000
desktop

125
00:04:10,000 --> 00:04:14,400
license java sc advanced desktop

126
00:04:14,400 --> 00:04:16,959
a further addition to this is that in

127
00:04:16,959 --> 00:04:18,399
the latest price list perpetual

128
00:04:18,399 --> 00:04:20,320
licensing is no longer available

129
00:04:20,320 --> 00:04:22,880
only subscription so it looks as though

130
00:04:22,880 --> 00:04:24,400
this could be another push to get

131
00:04:24,400 --> 00:04:26,560
customers to move to the cloud

132
00:04:26,560 --> 00:04:28,000
chris do you have any views about this

133
00:04:28,000 --> 00:04:29,919
change to the price list sorry i jumped

134
00:04:29,919 --> 00:04:31,360
ahead on my screen

135
00:04:31,360 --> 00:04:34,320
no yeah it's it's it's relatively new uh

136
00:04:34,320 --> 00:04:36,080
we noticed that at the beginning of 2019

137
00:04:36,080 --> 00:04:37,759
that the perpetual licensing

138
00:04:37,759 --> 00:04:39,759
uh was no longer available on the price

139
00:04:39,759 --> 00:04:41,840
list uh they had mentioned this before

140
00:04:41,840 --> 00:04:43,120
that that was the case

141
00:04:43,120 --> 00:04:45,919
but it does indeed look like uh orica

142
00:04:45,919 --> 00:04:47,759
oracle's trying to push

143
00:04:47,759 --> 00:04:50,560
uh its customers into into subscriptions

144
00:04:50,560 --> 00:04:51,759
more and more

145
00:04:51,759 --> 00:04:53,199
and this is what we're seeing across the

146
00:04:53,199 --> 00:04:55,440
board basically

147
00:04:55,440 --> 00:04:59,600
thanks chris so whether you have

148
00:04:59,600 --> 00:05:01,120
whether you pay for job or not isn't

149
00:05:01,120 --> 00:05:02,960
just dependent on the version of java

150
00:05:02,960 --> 00:05:03,680
you're using

151
00:05:03,680 --> 00:05:06,639
but how you are using it before diving

152
00:05:06,639 --> 00:05:07,759
into the complexities

153
00:05:07,759 --> 00:05:10,400
it's worth a reminder on what java sc is

154
00:05:10,400 --> 00:05:12,639
made up of as standard

155
00:05:12,639 --> 00:05:14,320
and free of charge under the oracle

156
00:05:14,320 --> 00:05:16,639
binary license code agreement

157
00:05:16,639 --> 00:05:18,160
javascript is made up of several

158
00:05:18,160 --> 00:05:19,840
features and components

159
00:05:19,840 --> 00:05:21,919
these include the java development kit

160
00:05:21,919 --> 00:05:23,360
the jdk

161
00:05:23,360 --> 00:05:25,600
and java fx software development kit the

162
00:05:25,600 --> 00:05:26,960
sdk

163
00:05:26,960 --> 00:05:29,759
the java runtime environment the jre

164
00:05:29,759 --> 00:05:31,360
together with the java fx

165
00:05:31,360 --> 00:05:34,639
runtime and j rocket jdk

166
00:05:34,639 --> 00:05:36,560
and the commercial features are those

167
00:05:36,560 --> 00:05:38,639
that oracle has developed on top of java

168
00:05:38,639 --> 00:05:39,919
se

169
00:05:39,919 --> 00:05:41,280
one of the most common commercial

170
00:05:41,280 --> 00:05:43,759
features is the msi enterprise jre

171
00:05:43,759 --> 00:05:44,880
installer

172
00:05:44,880 --> 00:05:47,280
many end users use this to distribute

173
00:05:47,280 --> 00:05:50,000
java runtime to desktops and laptops

174
00:05:50,000 --> 00:05:51,600
but should be aware that it requires a

175
00:05:51,600 --> 00:05:53,680
license if it's been used for internal

176
00:05:53,680 --> 00:05:55,840
business operations production or

177
00:05:55,840 --> 00:05:57,520
commercial purposes

178
00:05:57,520 --> 00:05:59,600
the important thing to say the important

179
00:05:59,600 --> 00:06:00,560
thing to know though

180
00:06:00,560 --> 00:06:02,479
is if the commercial features are being

181
00:06:02,479 --> 00:06:05,280
used to design develop and test programs

182
00:06:05,280 --> 00:06:07,919
then no license is required commercial

183
00:06:07,919 --> 00:06:09,520
features only need a license

184
00:06:09,520 --> 00:06:10,720
if they're being used for business

185
00:06:10,720 --> 00:06:12,880
operations production or commercial

186
00:06:12,880 --> 00:06:14,319
purposes

187
00:06:14,319 --> 00:06:16,160
so this is how it was and it's now

188
00:06:16,160 --> 00:06:17,759
changing or rather i should say it's

189
00:06:17,759 --> 00:06:19,840
changed from january

190
00:06:19,840 --> 00:06:21,759
if you are using java se for general

191
00:06:21,759 --> 00:06:23,919
purpose computing or for development

192
00:06:23,919 --> 00:06:26,000
then this is still free

193
00:06:26,000 --> 00:06:27,680
um chris have you got an example of

194
00:06:27,680 --> 00:06:31,039
general purpose computing please

195
00:06:31,039 --> 00:06:34,000
yes it's basically running uh an

196
00:06:34,000 --> 00:06:35,120
application

197
00:06:35,120 --> 00:06:37,120
i mean even even home users that are

198
00:06:37,120 --> 00:06:38,160
using it for uh

199
00:06:38,160 --> 00:06:40,880
for uh games uh it could potentially be

200
00:06:40,880 --> 00:06:41,759
something

201
00:06:41,759 --> 00:06:44,479
um so that's what really meant with with

202
00:06:44,479 --> 00:06:45,039
general

203
00:06:45,039 --> 00:06:48,000
purpose computing uh just common

204
00:06:48,000 --> 00:06:49,360
computer tasks

205
00:06:49,360 --> 00:06:51,520
on personal desktops notebooks that sort

206
00:06:51,520 --> 00:06:53,759
of thing

207
00:06:53,919 --> 00:06:56,479
thanks chris

208
00:06:57,520 --> 00:06:59,120
but if it's been used in a production or

209
00:06:59,120 --> 00:07:00,720
a commercial environment then a license

210
00:07:00,720 --> 00:07:02,400
would definitely be required

211
00:07:02,400 --> 00:07:04,720
so when you're looking yeah so when you

212
00:07:04,720 --> 00:07:06,080
look into your java usage

213
00:07:06,080 --> 00:07:07,759
you need to know what you are using and

214
00:07:07,759 --> 00:07:10,800
how you are using it

215
00:07:12,160 --> 00:07:13,680
before we move on to look at the support

216
00:07:13,680 --> 00:07:15,840
roadmap it's

217
00:07:15,840 --> 00:07:17,759
worth looking at how oracle define their

218
00:07:17,759 --> 00:07:19,199
customer types

219
00:07:19,199 --> 00:07:21,840
they classify customers for support as

220
00:07:21,840 --> 00:07:23,440
this has an impact on whether they are

221
00:07:23,440 --> 00:07:25,520
eligible for public updates

222
00:07:25,520 --> 00:07:27,680
at a high level they are they classify

223
00:07:27,680 --> 00:07:28,960
them into three types

224
00:07:28,960 --> 00:07:30,639
have oracle customers commercial

225
00:07:30,639 --> 00:07:33,039
customers and personal users

226
00:07:33,039 --> 00:07:34,720
oracle customers are those with an

227
00:07:34,720 --> 00:07:36,880
active java subscription or valid

228
00:07:36,880 --> 00:07:39,199
support contract that includes java se

229
00:07:39,199 --> 00:07:41,599
under its user rights again chris over

230
00:07:41,599 --> 00:07:43,440
to you for an example of contracts that

231
00:07:43,440 --> 00:07:44,000
could include

232
00:07:44,000 --> 00:07:47,039
rights to use java so

233
00:07:47,039 --> 00:07:49,680
besides the the the standard licenses

234
00:07:49,680 --> 00:07:51,039
for java such as the

235
00:07:51,039 --> 00:07:54,560
the java sc desktop advanced desktop or

236
00:07:54,560 --> 00:07:56,879
suite you can have a subscription

237
00:07:56,879 --> 00:07:59,840
but you can also have other oracle

238
00:07:59,840 --> 00:08:02,800
products that include a license for

239
00:08:02,800 --> 00:08:07,199
java it could be weblogic for instance

240
00:08:07,199 --> 00:08:09,680
you have internet application server

241
00:08:09,680 --> 00:08:11,280
enterprise edition

242
00:08:11,280 --> 00:08:14,000
uh peoplesoft licenses they all include

243
00:08:14,000 --> 00:08:15,680
the right to use java as he

244
00:08:15,680 --> 00:08:18,080
as well

245
00:08:18,720 --> 00:08:21,759
thank you the other the next one is

246
00:08:21,759 --> 00:08:22,560
commercial

247
00:08:22,560 --> 00:08:25,280
customers these are non-oracle customers

248
00:08:25,280 --> 00:08:26,800
the ones who don't have a valid support

249
00:08:26,800 --> 00:08:27,680
contract

250
00:08:27,680 --> 00:08:29,840
who use java se for business commercial

251
00:08:29,840 --> 00:08:31,280
or production purposes

252
00:08:31,280 --> 00:08:33,200
as part of a java application developed

253
00:08:33,200 --> 00:08:35,679
internally or delivered by a third party

254
00:08:35,679 --> 00:08:37,760
and personal users are users using

255
00:08:37,760 --> 00:08:39,919
javasc to develop applications as a

256
00:08:39,919 --> 00:08:40,559
hobby

257
00:08:40,559 --> 00:08:42,399
or for educational purposes or to play

258
00:08:42,399 --> 00:08:44,320
games or run applications

259
00:08:44,320 --> 00:08:45,519
chris do you have anything to add to

260
00:08:45,519 --> 00:08:47,200
that those definitions before i hand

261
00:08:47,200 --> 00:08:49,680
over to you to talk about the support

262
00:08:49,680 --> 00:08:52,720
no i mean the the most

263
00:08:52,720 --> 00:08:54,720
common one here will be the commercial

264
00:08:54,720 --> 00:08:57,200
users and those are the most interesting

265
00:08:57,200 --> 00:09:00,000
ones from a a licensed perspective here

266
00:09:00,000 --> 00:09:01,600
oracle customers will already

267
00:09:01,600 --> 00:09:04,000
usually have a right to use java for

268
00:09:04,000 --> 00:09:04,880
commercial

269
00:09:04,880 --> 00:09:08,080
purposes but the commercial users that

270
00:09:08,080 --> 00:09:10,000
are using java for commercial purposes

271
00:09:10,000 --> 00:09:11,360
without a license

272
00:09:11,360 --> 00:09:13,920
uh and and those are the ones that that

273
00:09:13,920 --> 00:09:15,279
will definitely need to take a look at

274
00:09:15,279 --> 00:09:16,800
their java usage

275
00:09:16,800 --> 00:09:18,720
um to understand if they are actually

276
00:09:18,720 --> 00:09:21,279
licensed to do this correctly

277
00:09:21,279 --> 00:09:23,440
okay thank you i'm going to hand over to

278
00:09:23,440 --> 00:09:25,360
you now

279
00:09:25,360 --> 00:09:28,640
to talk about the support roadmap sure

280
00:09:28,640 --> 00:09:33,279
so um this slide displays the support

281
00:09:33,279 --> 00:09:34,399
roadmap for

282
00:09:34,399 --> 00:09:38,080
java as it currently exists

283
00:09:38,080 --> 00:09:41,200
so the the the recent announcement was

284
00:09:41,200 --> 00:09:41,760
for the

285
00:09:41,760 --> 00:09:45,200
uh long-term support version 8

286
00:09:45,200 --> 00:09:49,279
which was introduced in march 2014

287
00:09:49,279 --> 00:09:52,000
and uh recently it has been announced

288
00:09:52,000 --> 00:09:54,240
that starting from january 2019

289
00:09:54,240 --> 00:09:56,560
uh there will no longer be public

290
00:09:56,560 --> 00:09:58,160
updates available

291
00:09:58,160 --> 00:10:01,440
for uh commercial purposes um

292
00:10:01,440 --> 00:10:05,200
so this means that unless

293
00:10:05,200 --> 00:10:08,079
you are

294
00:10:08,720 --> 00:10:12,000
as a customer willing to accept using a

295
00:10:12,000 --> 00:10:14,000
version of java that is no longer

296
00:10:14,000 --> 00:10:15,760
updated

297
00:10:15,760 --> 00:10:18,079
you will require a commercial license

298
00:10:18,079 --> 00:10:19,600
for this

299
00:10:19,600 --> 00:10:22,079
so the next upcoming release or update

300
00:10:22,079 --> 00:10:23,680
of java will be in april

301
00:10:23,680 --> 00:10:25,920
and that will no longer be available as

302
00:10:25,920 --> 00:10:26,880
a public

303
00:10:26,880 --> 00:10:29,120
free update so you will need a license

304
00:10:29,120 --> 00:10:29,920
for that

305
00:10:29,920 --> 00:10:32,640
exception to this is the personal user

306
00:10:32,640 --> 00:10:33,360
uh

307
00:10:33,360 --> 00:10:36,480
they can still uh use updates until the

308
00:10:36,480 --> 00:10:37,839
end of 2020

309
00:10:37,839 --> 00:10:40,399
uh but for for production purposes this

310
00:10:40,399 --> 00:10:42,880
is no longer available

311
00:10:42,880 --> 00:10:44,720
so you see that that oracle is shifting

312
00:10:44,720 --> 00:10:46,320
away from their old

313
00:10:46,320 --> 00:10:49,600
uh license uh that

314
00:10:49,600 --> 00:10:51,680
that was still providing free public

315
00:10:51,680 --> 00:10:52,640
updates

316
00:10:52,640 --> 00:10:55,120
moving more into a six-month cadence

317
00:10:55,120 --> 00:10:58,240
where new features will be released in

318
00:10:58,240 --> 00:11:01,360
in subsequent versions of java such as

319
00:11:01,360 --> 00:11:05,040
nine and ten uh and they will

320
00:11:05,040 --> 00:11:07,760
completely change the way uh that oracle

321
00:11:07,760 --> 00:11:09,120
java is licensed

322
00:11:09,120 --> 00:11:11,760
with version 11 which will basically

323
00:11:11,760 --> 00:11:13,360
come in two flavors

324
00:11:13,360 --> 00:11:17,279
a commercial license which will have

325
00:11:17,279 --> 00:11:18,720
enterprise support and enterprise

326
00:11:18,720 --> 00:11:20,640
management capabilities

327
00:11:20,640 --> 00:11:25,680
and a open source

328
00:11:25,760 --> 00:11:29,120
license for still free usage

329
00:11:29,120 --> 00:11:32,320
through the open jdk release

330
00:11:32,320 --> 00:11:35,920
but they will move away from the old way

331
00:11:35,920 --> 00:11:37,440
of doing it which were the public

332
00:11:37,440 --> 00:11:38,079
updates

333
00:11:38,079 --> 00:11:40,079
that will no longer be be available to

334
00:11:40,079 --> 00:11:41,360
customers

335
00:11:41,360 --> 00:11:44,480
going forward and this does

336
00:11:44,480 --> 00:11:48,640
impact a lot of customers or users of

337
00:11:48,640 --> 00:11:49,600
java that

338
00:11:49,600 --> 00:11:51,680
are reliant on a specific version such

339
00:11:51,680 --> 00:11:54,160
as 8 because it was an lts version

340
00:11:54,160 --> 00:11:56,800
they will need to make a choice in in

341
00:11:56,800 --> 00:11:58,560
how they will continue to use

342
00:11:58,560 --> 00:12:02,320
either accept uh not not updating

343
00:12:02,320 --> 00:12:05,519
or acquiring a a license uh going

344
00:12:05,519 --> 00:12:06,639
forward

345
00:12:06,639 --> 00:12:10,160
uh or move to alternatives um so

346
00:12:10,160 --> 00:12:12,079
we'll discuss it on the next slide

347
00:12:12,079 --> 00:12:14,639
please sarah

348
00:12:21,360 --> 00:12:25,519
so possible courses of action that

349
00:12:25,519 --> 00:12:28,000
customers can take

350
00:12:28,000 --> 00:12:31,040
after this announcement it's it's

351
00:12:31,040 --> 00:12:33,680
i think important to understand first

352
00:12:33,680 --> 00:12:34,800
[Music]

353
00:12:34,800 --> 00:12:37,680
what type of usage customers are making

354
00:12:37,680 --> 00:12:38,399
so

355
00:12:38,399 --> 00:12:41,360
identify which of the usage of java

356
00:12:41,360 --> 00:12:43,920
would fall under commercial business use

357
00:12:43,920 --> 00:12:47,440
and which wouldn't and if you understand

358
00:12:47,440 --> 00:12:47,920
that

359
00:12:47,920 --> 00:12:50,639
and have a view on that then you have a

360
00:12:50,639 --> 00:12:53,040
couple of options first you could stay

361
00:12:53,040 --> 00:12:56,880
with your current version of java se8

362
00:12:56,880 --> 00:12:59,200
that could be a course of action to take

363
00:12:59,200 --> 00:13:03,279
that that still falls within the old

364
00:13:03,279 --> 00:13:06,000
licensing scheme so as long as you don't

365
00:13:06,000 --> 00:13:06,720
use

366
00:13:06,720 --> 00:13:10,000
commercial features for uh

367
00:13:10,000 --> 00:13:13,279
for production purposes um and

368
00:13:13,279 --> 00:13:14,800
and you use it for general purpose

369
00:13:14,800 --> 00:13:16,720
computing that's still totally valid you

370
00:13:16,720 --> 00:13:18,880
can use your old license to do that

371
00:13:18,880 --> 00:13:23,360
um you can of course always go with each

372
00:13:23,360 --> 00:13:25,200
subsequent version of javascript and

373
00:13:25,200 --> 00:13:27,200
update every six months

374
00:13:27,200 --> 00:13:29,680
that's probably not a good course to

375
00:13:29,680 --> 00:13:32,160
take for production purposes but

376
00:13:32,160 --> 00:13:35,279
it's valid from a license perspective um

377
00:13:35,279 --> 00:13:38,639
you could move to the open jdk that

378
00:13:38,639 --> 00:13:40,240
oracle is also releasing

379
00:13:40,240 --> 00:13:43,920
um that is interchangeable with

380
00:13:43,920 --> 00:13:46,560
the oracle java jdk that they are

381
00:13:46,560 --> 00:13:47,680
releasing

382
00:13:47,680 --> 00:13:50,480
it's just not supported in the same way

383
00:13:50,480 --> 00:13:53,760
as as oracle java is

384
00:13:53,760 --> 00:13:57,360
you could of course go to oracle and get

385
00:13:57,360 --> 00:14:00,639
a license and get support

386
00:14:00,639 --> 00:14:03,360
and updates as we've seen uh they will

387
00:14:03,360 --> 00:14:04,639
provide updates

388
00:14:04,639 --> 00:14:07,680
uh for a number of years uh going

389
00:14:07,680 --> 00:14:09,600
forward for java se8

390
00:14:09,600 --> 00:14:12,320
uh the extended support uh or the

391
00:14:12,320 --> 00:14:14,079
premier premier support will

392
00:14:14,079 --> 00:14:17,040
continue up to 2022 and extended support

393
00:14:17,040 --> 00:14:18,240
will be available

394
00:14:18,240 --> 00:14:21,440
up to march 2025. um

395
00:14:21,440 --> 00:14:23,680
that is a possibility and and paying

396
00:14:23,680 --> 00:14:26,079
oracle for

397
00:14:26,079 --> 00:14:29,040
support and updates through a license or

398
00:14:29,040 --> 00:14:30,320
a subscription

399
00:14:30,320 --> 00:14:32,880
also allows you to use each previous

400
00:14:32,880 --> 00:14:33,440
version and

401
00:14:33,440 --> 00:14:35,680
an upcoming version as well so that's

402
00:14:35,680 --> 00:14:39,040
definitely a possibility

403
00:14:39,040 --> 00:14:42,079
another option that you could have is is

404
00:14:42,079 --> 00:14:43,680
paying another company

405
00:14:43,680 --> 00:14:46,959
for support of oracle java so

406
00:14:46,959 --> 00:14:49,519
you could go with licensing through

407
00:14:49,519 --> 00:14:50,880
operating systems in

408
00:14:50,880 --> 00:14:55,279
some cases or go to the adopt open jdk

409
00:14:55,279 --> 00:14:58,240
organization and and get support that

410
00:14:58,240 --> 00:14:59,279
way

411
00:14:59,279 --> 00:15:02,720
or lastly the alternative could be

412
00:15:02,720 --> 00:15:05,519
that you license it through existing

413
00:15:05,519 --> 00:15:07,279
licenses that you have for other

414
00:15:07,279 --> 00:15:07,839
products

415
00:15:07,839 --> 00:15:11,680
that already include the right to use

416
00:15:11,680 --> 00:15:15,040
java as e so all of these are

417
00:15:15,040 --> 00:15:18,240
our options uh that are on on the table

418
00:15:18,240 --> 00:15:21,120
for customers and it depends a little

419
00:15:21,120 --> 00:15:21,519
bit on

420
00:15:21,519 --> 00:15:24,720
the type of usage and the requirements

421
00:15:24,720 --> 00:15:26,480
that you have as an organization

422
00:15:26,480 --> 00:15:29,360
uh which would be the best um course of

423
00:15:29,360 --> 00:15:30,800
action for you as an organization to

424
00:15:30,800 --> 00:15:32,399
take

425
00:15:32,399 --> 00:15:33,839
chris can you give an example of

426
00:15:33,839 --> 00:15:36,000
existing licenses that

427
00:15:36,000 --> 00:15:39,680
might exist that cover javi

428
00:15:39,680 --> 00:15:41,920
yeah so we we we mentioned a couple

429
00:15:41,920 --> 00:15:42,880
before uh

430
00:15:42,880 --> 00:15:46,399
about logic uh um that that

431
00:15:46,399 --> 00:15:49,199
uh oracle uh sells as well it comes

432
00:15:49,199 --> 00:15:50,800
included with with java as e

433
00:15:50,800 --> 00:15:52,560
in some cases javascript advanced or

434
00:15:52,560 --> 00:15:53,839
sweet

435
00:15:53,839 --> 00:15:56,000
internet application server enterprise

436
00:15:56,000 --> 00:15:59,519
edition does include java se

437
00:15:59,519 --> 00:16:03,680
you have web center you have

438
00:16:03,680 --> 00:16:07,519
peoplesoft even old ba licenses used to

439
00:16:07,519 --> 00:16:08,639
include some

440
00:16:08,639 --> 00:16:10,399
java features as well so there are a

441
00:16:10,399 --> 00:16:12,800
number of products coming from oracle

442
00:16:12,800 --> 00:16:16,160
that includes the right to use

443
00:16:16,160 --> 00:16:20,160
java so that's definitely a possibility

444
00:16:20,160 --> 00:16:21,839
and something you need to investigate as

445
00:16:21,839 --> 00:16:23,920
an organization

446
00:16:23,920 --> 00:16:26,399
thanks chris

447
00:16:28,320 --> 00:16:36,560
so i guess the next slide

448
00:16:36,560 --> 00:16:39,120
so how can i.t asset management in

449
00:16:39,120 --> 00:16:39,680
general

450
00:16:39,680 --> 00:16:42,800
help you um i think

451
00:16:42,800 --> 00:16:45,040
first the first thing to understand in

452
00:16:45,040 --> 00:16:46,000
any organization

453
00:16:46,000 --> 00:16:49,040
is what do i have

454
00:16:49,040 --> 00:16:52,240
do you actually make use of java

455
00:16:52,240 --> 00:16:56,880
on which machines is it the full jdk

456
00:16:56,880 --> 00:17:00,399
is it just the runtime environment

457
00:17:00,399 --> 00:17:03,519
which versions do i have so all of this

458
00:17:03,519 --> 00:17:04,240
uh

459
00:17:04,240 --> 00:17:07,599
would be the starting point for any

460
00:17:07,599 --> 00:17:09,760
asset management activity related to

461
00:17:09,760 --> 00:17:10,959
java

462
00:17:10,959 --> 00:17:13,280
so snow can can definitely support in

463
00:17:13,280 --> 00:17:14,959
that we have the ability

464
00:17:14,959 --> 00:17:18,000
uh to identify with our asian technology

465
00:17:18,000 --> 00:17:20,640
the version and addition of java that is

466
00:17:20,640 --> 00:17:22,880
being deployed within your organization

467
00:17:22,880 --> 00:17:26,480
in some case we can see usage as well

468
00:17:26,480 --> 00:17:28,720
and in some cases we can identify some

469
00:17:28,720 --> 00:17:30,480
of the commercial features that are in

470
00:17:30,480 --> 00:17:31,280
use

471
00:17:31,280 --> 00:17:32,799
and this is definitely the starting

472
00:17:32,799 --> 00:17:35,360
point for any uh

473
00:17:35,360 --> 00:17:37,520
any i.t asset management activity you do

474
00:17:37,520 --> 00:17:38,559
when it comes to

475
00:17:38,559 --> 00:17:41,679
to oracle java understand what you have

476
00:17:41,679 --> 00:17:44,960
where you have it and then you would

477
00:17:44,960 --> 00:17:46,320
need to identify

478
00:17:46,320 --> 00:17:50,400
the type of usage that you make of java

479
00:17:50,400 --> 00:17:52,000
we can identify if this is just for

480
00:17:52,000 --> 00:17:53,919
testing purposes of course or this is

481
00:17:53,919 --> 00:17:55,679
for for business processing

482
00:17:55,679 --> 00:17:58,960
or or production purposes but we can

483
00:17:58,960 --> 00:18:00,080
definitely support

484
00:18:00,080 --> 00:18:03,120
in identifying where java is running

485
00:18:03,120 --> 00:18:07,679
uh and on which machines it is installed

486
00:18:07,679 --> 00:18:10,720
so that would be a way where

487
00:18:10,720 --> 00:18:14,080
snow can support of course our partners

488
00:18:14,080 --> 00:18:15,760
can use this information as well to

489
00:18:15,760 --> 00:18:17,760
support you with

490
00:18:17,760 --> 00:18:20,240
identifying the risk that you have

491
00:18:20,240 --> 00:18:21,600
within your organization

492
00:18:21,600 --> 00:18:24,320
if there is any risk and potentially a

493
00:18:24,320 --> 00:18:25,679
course of action to take

494
00:18:25,679 --> 00:18:29,840
based on that data

495
00:18:38,720 --> 00:18:41,520
right thank you presenters for that

496
00:18:41,520 --> 00:18:42,080
information

497
00:18:42,080 --> 00:18:44,320
now i have shared with you presenters

498
00:18:44,320 --> 00:18:45,600
the questions that came

499
00:18:45,600 --> 00:18:47,840
in and there's more still coming in that

500
00:18:47,840 --> 00:18:50,000
i'll be sharing with you

501
00:18:50,000 --> 00:18:52,720
keep in mind as you answer the questions

502
00:18:52,720 --> 00:18:54,160
many of them were asked as you went

503
00:18:54,160 --> 00:18:55,679
along and you might have partially

504
00:18:55,679 --> 00:18:56,000
answered

505
00:18:56,000 --> 00:18:59,919
them or completely answered them before

506
00:18:59,919 --> 00:19:02,160
reaching this question and answer period

507
00:19:02,160 --> 00:19:04,080
so if you would please go ahead and take

508
00:19:04,080 --> 00:19:06,400
a look at the first one chris and sarah

509
00:19:06,400 --> 00:19:08,960
that i sent to you you want me to read

510
00:19:08,960 --> 00:19:10,960
it out for everyone or would you like to

511
00:19:10,960 --> 00:19:13,360
do that

512
00:19:13,520 --> 00:19:15,120
jenny can you read them out so everybody

513
00:19:15,120 --> 00:19:16,559
can hear them please

514
00:19:16,559 --> 00:19:19,679
sure so the first question is

515
00:19:19,679 --> 00:19:22,480
java sc the the runtime or the

516
00:19:22,480 --> 00:19:23,360
development

517
00:19:23,360 --> 00:19:26,640
kit prior to jdk 11 is under

518
00:19:26,640 --> 00:19:29,919
bcl license it requires a license only

519
00:19:29,919 --> 00:19:32,720
if commercial features are used correct

520
00:19:32,720 --> 00:19:34,400
and then the other part of the question

521
00:19:34,400 --> 00:19:36,840
how can we detect the commercial

522
00:19:36,840 --> 00:19:38,960
features

523
00:19:38,960 --> 00:19:42,640
so um it requires a license

524
00:19:42,640 --> 00:19:45,440
indeed if commercial features are used

525
00:19:45,440 --> 00:19:46,559
for

526
00:19:46,559 --> 00:19:49,039
anything other than testing prototyping

527
00:19:49,039 --> 00:19:50,840
and developing

528
00:19:50,840 --> 00:19:53,840
um but it's not only the case that you

529
00:19:53,840 --> 00:19:56,080
only use a commercial license or require

530
00:19:56,080 --> 00:19:57,679
a commercial license if commercial

531
00:19:57,679 --> 00:19:58,880
features are used

532
00:19:58,880 --> 00:20:01,200
it's also the case that if you use

533
00:20:01,200 --> 00:20:02,960
oracle java for anything other than

534
00:20:02,960 --> 00:20:05,360
general purpose computer under the bcl

535
00:20:05,360 --> 00:20:10,000
you still require a license so

536
00:20:10,000 --> 00:20:13,679
the best the best

537
00:20:13,679 --> 00:20:15,679
example that i can give here would be

538
00:20:15,679 --> 00:20:16,880
like if you have

539
00:20:16,880 --> 00:20:19,520
something like uh for instance a blu-ray

540
00:20:19,520 --> 00:20:20,080
device

541
00:20:20,080 --> 00:20:22,320
or or uh you know software that's

542
00:20:22,320 --> 00:20:23,760
embedded in in

543
00:20:23,760 --> 00:20:26,480
uh wireless mobile telephones or

544
00:20:26,480 --> 00:20:27,600
something like that

545
00:20:27,600 --> 00:20:29,520
uh if java's in there that still

546
00:20:29,520 --> 00:20:31,280
requires a license but it's usually

547
00:20:31,280 --> 00:20:32,840
licensed through the

548
00:20:32,840 --> 00:20:35,919
the the product itself

549
00:20:35,919 --> 00:20:38,960
uh but it it's not for free

550
00:20:38,960 --> 00:20:40,960
that does require a specific commercial

551
00:20:40,960 --> 00:20:43,120
license now how can we detect if

552
00:20:43,120 --> 00:20:44,320
commercial features

553
00:20:44,320 --> 00:20:47,679
are are used uh or

554
00:20:47,679 --> 00:20:49,919
enabled uh it depends a little bit there

555
00:20:49,919 --> 00:20:51,919
are ways uh to do this

556
00:20:51,919 --> 00:20:53,600
i think it goes a little bit too beyond

557
00:20:53,600 --> 00:20:55,200
what we can do in in this

558
00:20:55,200 --> 00:20:58,320
um uh in this webinar

559
00:20:58,320 --> 00:21:02,080
this is a kind of a technical response

560
00:21:02,080 --> 00:21:03,840
but there are ways to extract the

561
00:21:03,840 --> 00:21:05,520
information on

562
00:21:05,520 --> 00:21:07,280
some of the commercial features at least

563
00:21:07,280 --> 00:21:09,120
that are

564
00:21:09,120 --> 00:21:12,320
deployed and used

565
00:21:12,320 --> 00:21:14,799
so we might want to take that offline

566
00:21:14,799 --> 00:21:15,360
and provide

567
00:21:15,360 --> 00:21:17,919
information on how we can detect that

568
00:21:17,919 --> 00:21:20,559
all right good the the questions will be

569
00:21:20,559 --> 00:21:23,039
provided and uh to snow software and

570
00:21:23,039 --> 00:21:24,480
they'll be able to respond

571
00:21:24,480 --> 00:21:27,679
later moving on to the next question uh

572
00:21:27,679 --> 00:21:29,600
where can we find a complete list of

573
00:21:29,600 --> 00:21:31,360
third-party vendors that cover

574
00:21:31,360 --> 00:21:34,720
java for their clients

575
00:21:35,360 --> 00:21:38,559
it's a good question um

576
00:21:38,559 --> 00:21:42,840
i'm not entirely sure if that exists

577
00:21:42,840 --> 00:21:45,200
um you know there are fairly

578
00:21:45,200 --> 00:21:49,360
uh complete lists coming from oracle

579
00:21:49,360 --> 00:21:52,799
um you can always find what's what's

580
00:21:52,799 --> 00:21:56,960
covered by other oracle licenses

581
00:21:57,440 --> 00:22:00,480
but i don't believe um a

582
00:22:00,480 --> 00:22:03,679
a full list of of all

583
00:22:03,679 --> 00:22:07,280
um uh products that that container lies

584
00:22:07,280 --> 00:22:08,320
for java

585
00:22:08,320 --> 00:22:11,200
is available at least i don't know if of

586
00:22:11,200 --> 00:22:12,159
any

587
00:22:12,159 --> 00:22:15,520
i've never seen that i know that there's

588
00:22:15,520 --> 00:22:16,480
a list on

589
00:22:16,480 --> 00:22:19,410
there's some information available on

590
00:22:19,410 --> 00:22:21,760
[Music]

591
00:22:21,760 --> 00:22:23,520
let's say linux distributors that are

592
00:22:23,520 --> 00:22:25,600
disturbing in it as part of their

593
00:22:25,600 --> 00:22:26,960
operating system

594
00:22:26,960 --> 00:22:30,159
or third-party organizations that

595
00:22:30,159 --> 00:22:30,720
support

596
00:22:30,720 --> 00:22:34,400
java such as azul or ibm

597
00:22:34,400 --> 00:22:36,880
but i don't know if that list is is

598
00:22:36,880 --> 00:22:38,000
complete if there

599
00:22:38,000 --> 00:22:40,240
are potentially others i'm sure there

600
00:22:40,240 --> 00:22:42,159
are but i don't believe there's

601
00:22:42,159 --> 00:22:45,280
a full list available

602
00:22:45,280 --> 00:22:47,600
very good thank you for that information

603
00:22:47,600 --> 00:22:49,120
the next one is regarding

604
00:22:49,120 --> 00:22:52,880
snow itself snow dis database

605
00:22:52,880 --> 00:22:55,520
is it set up to help identify the

606
00:22:55,520 --> 00:22:56,559
footprint

607
00:22:56,559 --> 00:22:58,320
so we can begin discussions with the

608
00:22:58,320 --> 00:23:00,799
users and we're responsible parties on

609
00:23:00,799 --> 00:23:03,520
next steps

610
00:23:03,679 --> 00:23:07,120
so uh our des database is set up to

611
00:23:07,120 --> 00:23:10,400
identify certain footprints

612
00:23:10,400 --> 00:23:13,120
so it definitely will provide you with

613
00:23:13,120 --> 00:23:14,960
the information

614
00:23:14,960 --> 00:23:17,440
as a starting point

615
00:23:17,440 --> 00:23:19,360
[Music]

616
00:23:19,360 --> 00:23:21,280
there are still some things that we

617
00:23:21,280 --> 00:23:23,200
currently cannot identify

618
00:23:23,200 --> 00:23:26,640
based on just a raw inventory

619
00:23:26,640 --> 00:23:28,320
there are some things that we will

620
00:23:28,320 --> 00:23:30,000
probably need to develop some scripts to

621
00:23:30,000 --> 00:23:30,880
capture

622
00:23:30,880 --> 00:23:33,919
more information and be even more uh

623
00:23:33,919 --> 00:23:36,480
thorough in the reporting that we can do

624
00:23:36,480 --> 00:23:38,080
and that's something that my

625
00:23:38,080 --> 00:23:40,320
team is currently working on to develop

626
00:23:40,320 --> 00:23:43,120
a solution for that

627
00:23:43,120 --> 00:23:46,240
but what we can provide to you is

628
00:23:46,240 --> 00:23:47,919
already in a database and

629
00:23:47,919 --> 00:23:49,520
is available to all our customers

630
00:23:49,520 --> 00:23:51,520
running our agents

631
00:23:51,520 --> 00:23:53,200
all right good thank you now this is

632
00:23:53,200 --> 00:23:55,279
another snow specific question you might

633
00:23:55,279 --> 00:23:57,360
have addressed it

634
00:23:57,360 --> 00:23:59,360
java is required for snow agent

635
00:23:59,360 --> 00:24:01,520
deployment how's oracle's changes

636
00:24:01,520 --> 00:24:03,440
impacting the license requirements in

637
00:24:03,440 --> 00:24:06,480
such a scenario

638
00:24:06,640 --> 00:24:11,200
so again it does impact

639
00:24:11,200 --> 00:24:14,880
our solution going forward

640
00:24:14,880 --> 00:24:17,039
so we recently introduced support for

641
00:24:17,039 --> 00:24:18,080
open jdk

642
00:24:18,080 --> 00:24:20,559
which is possible now to use with our

643
00:24:20,559 --> 00:24:23,279
agent technology as an alternative to

644
00:24:23,279 --> 00:24:26,320
java from oracle uh

645
00:24:26,320 --> 00:24:29,760
but it's it's also possible to use

646
00:24:29,760 --> 00:24:31,919
the runtime environment that is

647
00:24:31,919 --> 00:24:32,960
delivered through

648
00:24:32,960 --> 00:24:35,200
either an operating system in linux for

649
00:24:35,200 --> 00:24:36,559
instance or

650
00:24:36,559 --> 00:24:38,960
licensed through the the distributor of

651
00:24:38,960 --> 00:24:40,480
your operating system that's also a

652
00:24:40,480 --> 00:24:41,600
possibility

653
00:24:41,600 --> 00:24:45,279
so snow is is relatively

654
00:24:45,279 --> 00:24:48,559
a vendor agnostic when it comes to java

655
00:24:48,559 --> 00:24:51,360
it's just important for specifically the

656
00:24:51,360 --> 00:24:51,919
oracle

657
00:24:51,919 --> 00:24:54,320
agent and our unix agent to have a

658
00:24:54,320 --> 00:24:56,159
runtime environment that it can can run

659
00:24:56,159 --> 00:24:56,880
on

660
00:24:56,880 --> 00:24:58,880
but openjdk is an alternative that we

661
00:24:58,880 --> 00:25:01,039
support

662
00:25:01,039 --> 00:25:02,720
all right good thank you now there's

663
00:25:02,720 --> 00:25:04,159
some examples uh

664
00:25:04,159 --> 00:25:06,880
questions coming in about specific

665
00:25:06,880 --> 00:25:08,640
products

666
00:25:08,640 --> 00:25:11,360
but um for those attendees i'm going to

667
00:25:11,360 --> 00:25:12,640
switch there's quite a number of

668
00:25:12,640 --> 00:25:14,320
questions i'm going to switch to the

669
00:25:14,320 --> 00:25:15,919
general questions first

670
00:25:15,919 --> 00:25:17,600
and if we don't get to your specific

671
00:25:17,600 --> 00:25:19,200
product questions

672
00:25:19,200 --> 00:25:22,720
then we will uh the snow be able to

673
00:25:22,720 --> 00:25:24,400
address them afterwards

674
00:25:24,400 --> 00:25:28,559
so here's one i think you have

675
00:25:28,880 --> 00:25:31,600
addressed our biggest challenge is

676
00:25:31,600 --> 00:25:33,440
trying to find out what java is being

677
00:25:33,440 --> 00:25:34,240
used

678
00:25:34,240 --> 00:25:38,240
where it would be covered under a parent

679
00:25:38,240 --> 00:25:41,120
uh application agreement how can snow

680
00:25:41,120 --> 00:25:43,840
find

681
00:25:44,000 --> 00:25:49,039
how and what is is used for it okay

682
00:25:49,679 --> 00:25:53,600
so that would mean uh

683
00:25:53,600 --> 00:25:56,080
that's currently not something that we

684
00:25:56,080 --> 00:25:56,640
can

685
00:25:56,640 --> 00:26:01,200
can do we don't tie the um

686
00:26:01,200 --> 00:26:04,240
the usage of java to any specific

687
00:26:04,240 --> 00:26:05,279
application

688
00:26:05,279 --> 00:26:06,720
that is something that i'm looking into

689
00:26:06,720 --> 00:26:08,400
with my team if that is possible to make

690
00:26:08,400 --> 00:26:09,679
that link

691
00:26:09,679 --> 00:26:11,840
but that is currently not something we

692
00:26:11,840 --> 00:26:12,960
can do

693
00:26:12,960 --> 00:26:15,919
with our basic inventory solution so

694
00:26:15,919 --> 00:26:16,960
unfortunately that is

695
00:26:16,960 --> 00:26:19,360
still a limitation of of the system at

696
00:26:19,360 --> 00:26:20,799
this time

697
00:26:20,799 --> 00:26:22,240
but it is definitely something we are

698
00:26:22,240 --> 00:26:24,000
looking into to make that link

699
00:26:24,000 --> 00:26:27,039
between the usage of java and

700
00:26:27,039 --> 00:26:29,600
the specific application or applications

701
00:26:29,600 --> 00:26:32,400
that are making use of java

702
00:26:32,400 --> 00:26:35,840
right thank you now the next question

703
00:26:35,840 --> 00:26:38,880
uh is about the snow omo

704
00:26:38,880 --> 00:26:42,080
module which uses java and it actually

705
00:26:42,080 --> 00:26:43,840
is a good question applying it directly

706
00:26:43,840 --> 00:26:44,480
to the

707
00:26:44,480 --> 00:26:48,000
your product uh that uses java is it

708
00:26:48,000 --> 00:26:50,080
counted as a production usage

709
00:26:50,080 --> 00:26:52,880
and does it require a commercial oracle

710
00:26:52,880 --> 00:26:55,840
java license

711
00:26:55,840 --> 00:26:58,960
so it would fall under general purpose

712
00:26:58,960 --> 00:27:02,720
uh but again uh going forward

713
00:27:02,720 --> 00:27:05,760
uh if if you want you know support if

714
00:27:05,760 --> 00:27:06,000
you're

715
00:27:06,000 --> 00:27:08,880
using oracle javascript uh at least the

716
00:27:08,880 --> 00:27:10,159
runtime there to run

717
00:27:10,159 --> 00:27:13,200
our omo agent as i mentioned before

718
00:27:13,200 --> 00:27:16,400
that that would uh require a license

719
00:27:16,400 --> 00:27:18,399
so that for that reason we are now

720
00:27:18,399 --> 00:27:21,440
supporting openjdk

721
00:27:21,440 --> 00:27:24,240
as an alternative to use the jre and

722
00:27:24,240 --> 00:27:24,640
that

723
00:27:24,640 --> 00:27:27,600
to run our agents uh going forward which

724
00:27:27,600 --> 00:27:29,039
is still

725
00:27:29,039 --> 00:27:33,600
available without a commercial license

726
00:27:33,600 --> 00:27:36,000
good thank you and for right now that

727
00:27:36,000 --> 00:27:36,799
completes the

728
00:27:36,799 --> 00:27:39,120
questions that we have uh from the

729
00:27:39,120 --> 00:27:40,000
audience

730
00:27:40,000 --> 00:27:42,320
you are of course going to receive

731
00:27:42,320 --> 00:27:43,200
information

732
00:27:43,200 --> 00:27:45,919
you'll receive an email follow-up from

733
00:27:45,919 --> 00:27:46,320
snow

734
00:27:46,320 --> 00:27:47,760
software and you would be able to

735
00:27:47,760 --> 00:27:49,840
respond to that as well

736
00:27:49,840 --> 00:27:51,760
and there's of course some contact

737
00:27:51,760 --> 00:27:53,440
information for you to generally you

738
00:27:53,440 --> 00:27:54,559
could reference this

739
00:27:54,559 --> 00:27:57,279
webinar the recording will also be

740
00:27:57,279 --> 00:27:59,840
available on the itam website in a

741
00:27:59,840 --> 00:28:03,840
snow software website a link to it

742
00:28:03,840 --> 00:28:06,240
early next week no later than early next

743
00:28:06,240 --> 00:28:06,880
week

744
00:28:06,880 --> 00:28:11,440
so please look for your answers there

745
00:28:11,760 --> 00:28:13,440
there's one question that's come in

746
00:28:13,440 --> 00:28:16,480
chris before we completely end out uh

747
00:28:16,480 --> 00:28:18,720
has snow heard any rumors from their

748
00:28:18,720 --> 00:28:20,720
customers about being audited

749
00:28:20,720 --> 00:28:23,840
for oracle java usage

750
00:28:23,840 --> 00:28:27,679
so what i've heard and i i speak quite

751
00:28:27,679 --> 00:28:29,520
frequently to my former colleagues at

752
00:28:29,520 --> 00:28:30,640
oracle is that

753
00:28:30,640 --> 00:28:33,840
for now uh the lms organization is in a

754
00:28:33,840 --> 00:28:34,799
bit of a

755
00:28:34,799 --> 00:28:37,600
holding pattern and we have heard from a

756
00:28:37,600 --> 00:28:40,159
couple of our customers that they have

757
00:28:40,159 --> 00:28:44,240
received uh some letters from uh

758
00:28:44,240 --> 00:28:46,159
oracle but it's mainly from the sales

759
00:28:46,159 --> 00:28:47,760
organization up until now

760
00:28:47,760 --> 00:28:50,320
uh that doesn't mean that oracle lms

761
00:28:50,320 --> 00:28:51,760
won't change this of course

762
00:28:51,760 --> 00:28:54,480
and and we you know we we're not sure if

763
00:28:54,480 --> 00:28:56,159
that will will happen

764
00:28:56,159 --> 00:28:59,840
um but it you know the changes in in

765
00:28:59,840 --> 00:29:00,640
licensing

766
00:29:00,640 --> 00:29:04,320
uh rules going forward do make it

767
00:29:04,320 --> 00:29:08,240
um probable that oracle will take some

768
00:29:08,240 --> 00:29:09,120
action on this

769
00:29:09,120 --> 00:29:12,880
uh as it's it's a challenge that most um

770
00:29:12,880 --> 00:29:15,840
customers using java will have uh and

771
00:29:15,840 --> 00:29:16,480
and

772
00:29:16,480 --> 00:29:17,840
you know it's definitely something that

773
00:29:17,840 --> 00:29:19,840
they need to worry about

774
00:29:19,840 --> 00:29:22,559
right good thank you and and thank you

775
00:29:22,559 --> 00:29:24,880
to both of our speakers today

776
00:29:24,880 --> 00:29:28,159
chris and sarah and any additional

777
00:29:28,159 --> 00:29:28,960
information

778
00:29:28,960 --> 00:29:30,960
you'll receive some follow-up and or

779
00:29:30,960 --> 00:29:32,159
you'll be able to

780
00:29:32,159 --> 00:29:34,720
listen again to this presentation on

781
00:29:34,720 --> 00:29:36,480
either of those two websites

782
00:29:36,480 --> 00:29:38,480
i thank you all for attending that

783
00:29:38,480 --> 00:29:40,720
concludes our presentation

784
00:29:40,720 --> 00:29:49,600
thank you thank you
```