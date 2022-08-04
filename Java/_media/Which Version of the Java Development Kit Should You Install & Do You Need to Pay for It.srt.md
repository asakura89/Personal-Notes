```srt
1
00:00:00,470 --> 00:00:03,030
- Alright, so which Java
Development Kit version

2
00:00:03,030 --> 00:00:05,730
do you need to install
and use as a developer,

3
00:00:05,730 --> 00:00:08,119
and also, do you have to pay to use it?

4
00:00:08,119 --> 00:00:10,887
Let's talk about that in today's video.

5
00:00:10,887 --> 00:00:14,387
(upbeat electronic music)

6
00:00:21,130 --> 00:00:23,100
Alright, so welcome back,
thanks for watching,

7
00:00:23,100 --> 00:00:24,880
and let's go through this in order.

8
00:00:24,880 --> 00:00:27,140
So I'm gonna start back at JDK 8.

9
00:00:27,140 --> 00:00:31,300
Now, that was the first that
Oracle brought out in 2014,

10
00:00:31,300 --> 00:00:33,210
and that was their
long-term support version,

11
00:00:33,210 --> 00:00:36,090
so if you started back around 2014,

12
00:00:36,090 --> 00:00:39,060
you saw that JDK 8 was updated for years,

13
00:00:39,060 --> 00:00:41,120
and in fact, there's
still updates available,

14
00:00:41,120 --> 00:00:43,570
but basically, that's now changing.

15
00:00:43,570 --> 00:00:46,750
JDK 11 is the version now
that Oracle is telling us

16
00:00:46,750 --> 00:00:49,030
is the long-term support version.

17
00:00:49,030 --> 00:00:50,310
So in other words,
that's gonna be supported

18
00:00:50,310 --> 00:00:54,150
until at least 2023, and
probably longer than that.

19
00:00:54,150 --> 00:00:56,510
But where it gets confusing is that

20
00:00:56,510 --> 00:00:58,810
this is long-term support
version, version 11,

21
00:00:58,810 --> 00:01:00,390
but they're also releasing a version

22
00:01:00,390 --> 00:01:02,250
of the JDK every six months,

23
00:01:02,250 --> 00:01:05,407
and, in fact, I'm recording
this in March 2019,

24
00:01:05,407 --> 00:01:07,730
JDK 12 has just come out,

25
00:01:07,730 --> 00:01:10,750
and what's confusing about
this release schedule

26
00:01:10,750 --> 00:01:13,140
is every six months they're
releasing a new version,

27
00:01:13,140 --> 00:01:17,260
and the version prior
is basically expiring

28
00:01:17,260 --> 00:01:18,650
and no longer being supported

29
00:01:18,650 --> 00:01:20,300
with no updates coming through.

30
00:01:20,300 --> 00:01:22,570
So this makes it quite
confusing at first glance

31
00:01:22,570 --> 00:01:24,240
as a developer to try and figure out

32
00:01:24,240 --> 00:01:26,360
which version you should be using.

33
00:01:26,360 --> 00:01:29,080
Now, the next long-term
support version of Java

34
00:01:29,080 --> 00:01:31,407
is currently, they're saying it's Java 17,

35
00:01:31,407 --> 00:01:33,130
or JDK version 17,

36
00:01:33,130 --> 00:01:34,200
and by my calculations,

37
00:01:34,200 --> 00:01:37,790
that's not gonna be released
till September 2021.

38
00:01:37,790 --> 00:01:39,770
So basically, every new version of Java

39
00:01:39,770 --> 00:01:44,690
that's coming out between
now and September 2021

40
00:01:44,690 --> 00:01:48,300
is going to be a version
that expires in six months.

41
00:01:48,300 --> 00:01:50,930
So consequently, it's my
opinion that most companies

42
00:01:50,930 --> 00:01:52,890
won't adopt these interim versions

43
00:01:52,890 --> 00:01:55,810
unless there's a specific
need for a specific version,

44
00:01:55,810 --> 00:01:58,960
a specific piece of
functionality in that version.

45
00:01:58,960 --> 00:02:00,210
What they'll do is they'll stick to

46
00:02:00,210 --> 00:02:01,550
the long-term support version,

47
00:02:01,550 --> 00:02:03,360
which is currently version 11,

48
00:02:03,360 --> 00:02:05,460
then perhaps in 2021 in September,

49
00:02:05,460 --> 00:02:08,120
when version 17 of the JDK comes out,

50
00:02:08,120 --> 00:02:09,520
they'll then update to that.

51
00:02:10,400 --> 00:02:13,520
Now the reason for that,
for sticking to JDK 11,

52
00:02:13,520 --> 00:02:15,840
is that if you move to JDK 12,

53
00:02:15,840 --> 00:02:17,270
because of the lack of support,

54
00:02:17,270 --> 00:02:18,740
because there's no more updates,

55
00:02:18,740 --> 00:02:21,070
particularly security updates,

56
00:02:21,070 --> 00:02:22,650
that's gonna be a risk for companies.

57
00:02:22,650 --> 00:02:26,750
So basically, if you start using JDK 12,

58
00:02:26,750 --> 00:02:28,880
you really are having to commit

59
00:02:28,880 --> 00:02:31,830
to update your software every six months,

60
00:02:31,830 --> 00:02:34,890
basically before the support expires,

61
00:02:34,890 --> 00:02:37,980
and before there's now no
longer any future updates.

62
00:02:37,980 --> 00:02:40,250
So from a company's perspective,

63
00:02:40,250 --> 00:02:42,290
if they've got a large team of people

64
00:02:42,290 --> 00:02:45,110
and a large investment in a
particular version of the JDK,

65
00:02:45,110 --> 00:02:47,000
they generally don't want to update

66
00:02:47,000 --> 00:02:49,770
on such a sort of quick release date,

67
00:02:49,770 --> 00:02:51,580
because even though it's six monthly,

68
00:02:51,580 --> 00:02:53,260
for a large application,

69
00:02:53,260 --> 00:02:56,050
that would be considered
quite a short period of time

70
00:02:56,050 --> 00:02:57,490
to try and keep things updated,

71
00:02:57,490 --> 00:02:58,740
because the whole thing is,

72
00:02:58,740 --> 00:03:01,870
with the JDK's updating
on a regular basis,

73
00:03:01,870 --> 00:03:02,950
things are changing,

74
00:03:02,950 --> 00:03:04,780
and it could be quite hard for a company

75
00:03:04,780 --> 00:03:06,340
to adopt that stance,

76
00:03:06,340 --> 00:03:09,930
and in fact, that's why
Oracle have committed

77
00:03:09,930 --> 00:03:12,140
to a long-term support version of the JDK.

78
00:03:12,140 --> 00:03:14,970
They recognise that it's
a considerable investment

79
00:03:14,970 --> 00:03:18,770
for some companies to update
their software at all,

80
00:03:18,770 --> 00:03:21,880
and they why they're committing
to JDK 11 for the long-term.

81
00:03:21,880 --> 00:03:24,490
So for that reason, I'm
gonna recommend that,

82
00:03:24,490 --> 00:03:27,680
generally speaking,
that you stick to JDK 11

83
00:03:27,680 --> 00:03:31,260
until such time as the next
long-term support version,

84
00:03:31,260 --> 00:03:32,350
which in this case, currently,

85
00:03:32,350 --> 00:03:33,460
as of the time I'm recording this,

86
00:03:33,460 --> 00:03:35,460
is JDK 17 comes out.

87
00:03:35,460 --> 00:03:37,290
And that's gonna stand you in good stead,

88
00:03:37,290 --> 00:03:40,610
because that's gonna be the
version that a lot of companies

89
00:03:40,610 --> 00:03:42,220
will be adopting and using,

90
00:03:42,220 --> 00:03:45,020
and obviously, if you are
familiar with that version,

91
00:03:45,020 --> 00:03:46,140
that'll go well if you're looking

92
00:03:46,140 --> 00:03:48,120
for a Java, basically, to work with.

93
00:03:48,120 --> 00:03:51,260
Now the other thing to keep
in mind here with this anyway,

94
00:03:51,260 --> 00:03:53,320
is that it's likely that
some of these changes

95
00:03:53,320 --> 00:03:57,820
that are introduced in
JDK 12, 13, and beyond,

96
00:03:57,820 --> 00:04:01,160
they'll probably be
rolled back into JDK 11

97
00:04:01,160 --> 00:04:01,993
at some point anyway,

98
00:04:01,993 --> 00:04:04,420
so in other words, it'll be
updated at some point anyway,

99
00:04:04,420 --> 00:04:07,750
because if you look back to JDK 9 and 10,

100
00:04:07,750 --> 00:04:09,450
those features in JDK 9 and 10

101
00:04:09,450 --> 00:04:11,540
were rolled into JDK 11 anyway.

102
00:04:11,540 --> 00:04:14,560
So the point of all this
is that it's probably good,

103
00:04:14,560 --> 00:04:17,040
in my opinion, if you're a developer,

104
00:04:17,040 --> 00:04:20,060
to actually stick to using
JDK 11 for the long term,

105
00:04:20,060 --> 00:04:22,660
unless you've got a specific
reason, specific feature

106
00:04:22,660 --> 00:04:25,510
that hasn't been updated in JDK 11 yet.

107
00:04:25,510 --> 00:04:27,690
And now, the other thing
is I wanted to introduce,

108
00:04:27,690 --> 00:04:29,640
I talked about it at
the start of the video,

109
00:04:29,640 --> 00:04:32,700
as a developer, which
version should you use,

110
00:04:32,700 --> 00:04:34,800
because there's two versions of the JDK,

111
00:04:34,800 --> 00:04:36,150
we're not talking version numbers here,

112
00:04:36,150 --> 00:04:38,230
I'm talking the actual products.

113
00:04:38,230 --> 00:04:41,300
We've got Oracle's
official version, the JDK,

114
00:04:41,300 --> 00:04:44,400
and there's also an OpenJDK.

115
00:04:44,400 --> 00:04:46,490
Now, you can use either
of those as a developer,

116
00:04:46,490 --> 00:04:49,670
but there are ramifications
if you're a company.

117
00:04:49,670 --> 00:04:51,010
Now, from a developer's perspective,

118
00:04:51,010 --> 00:04:52,580
you can download the Oracle version

119
00:04:52,580 --> 00:04:55,440
of the Java Development
Kit totally free of charge,

120
00:04:55,440 --> 00:04:56,970
there's no licencing constraints

121
00:04:56,970 --> 00:04:59,020
if you're using that version to develop

122
00:04:59,020 --> 00:05:00,530
and test your applications,

123
00:05:00,530 --> 00:05:02,330
so basically, no problem using that.

124
00:05:02,330 --> 00:05:04,640
But if you go to deploy that application,

125
00:05:04,640 --> 00:05:07,040
the company, technically, the company

126
00:05:07,040 --> 00:05:09,360
who you're deploying the application to,

127
00:05:09,360 --> 00:05:11,800
will have to pay to use the JDK.

128
00:05:11,800 --> 00:05:13,250
This is the Oracle version.

129
00:05:13,250 --> 00:05:16,390
However, if you go to the OpenJDK,

130
00:05:16,390 --> 00:05:18,240
that's basically an open source product,

131
00:05:18,240 --> 00:05:22,810
so JDK 11, Oracle are now
releasing that as open source,

132
00:05:22,810 --> 00:05:26,670
and it's virtually identical in features

133
00:05:26,670 --> 00:05:28,210
to the Oracle version.

134
00:05:28,210 --> 00:05:31,660
So in my opinion, there's really no reason

135
00:05:31,660 --> 00:05:34,040
for you to have to use the Oracle version

136
00:05:34,040 --> 00:05:36,530
unless you're writing
software for a company

137
00:05:36,530 --> 00:05:38,890
that doesn't like to use
open source software,

138
00:05:38,890 --> 00:05:40,600
or as a support contract.

139
00:05:40,600 --> 00:05:41,927
If already got support
contract with Oracle,

140
00:05:41,927 --> 00:05:44,490
and they're paying for Java anyway,

141
00:05:44,490 --> 00:05:46,610
there's no reason for them
not to use the Oracle version,

142
00:05:46,610 --> 00:05:49,210
so basically what I'm
saying as a developer,

143
00:05:49,210 --> 00:05:51,120
stick to the JDK version 11,

144
00:05:51,120 --> 00:05:54,050
and you probably can
stick to either version,

145
00:05:54,050 --> 00:05:55,020
either the Oracle version,

146
00:05:55,020 --> 00:05:57,550
because it's good practise
to use that, to instal that,

147
00:05:57,550 --> 00:06:00,230
because that's what you'll
likely see at a large company,

148
00:06:00,230 --> 00:06:04,460
but you can just as easily use
the OpenJDK version as well.

149
00:06:04,460 --> 00:06:07,860
Now, just another final
quick note, if the OpenJDK,

150
00:06:07,860 --> 00:06:10,360
sorry, not with the OpenJDK,
but the other version,

151
00:06:10,360 --> 00:06:12,300
the Oracle JDK version,

152
00:06:12,300 --> 00:06:14,860
companies will need to pay
for that, as I alluded to,

153
00:06:14,860 --> 00:06:17,220
and currently, Oracle's pricing model

154
00:06:17,220 --> 00:06:19,530
is basically per server, per CPU,

155
00:06:19,530 --> 00:06:22,200
so what they're trying to do is sort of,

156
00:06:22,200 --> 00:06:23,620
for enterprise customers, you've got,

157
00:06:23,620 --> 00:06:26,310
you know, a server with
lots of CPUs that charge,

158
00:06:26,310 --> 00:06:29,600
I think it's around $25 a month per CPU

159
00:06:29,600 --> 00:06:31,990
from off the top of my head,
that's the licencing agreement,

160
00:06:31,990 --> 00:06:34,530
but that licencing is all
done through Oracle anyway.

161
00:06:34,530 --> 00:06:36,480
So, to be totally free,

162
00:06:36,480 --> 00:06:39,500
I would suggest to stick to
the OpenJDK, it's open source,

163
00:06:39,500 --> 00:06:43,030
and it's practically identical
to the Oracle version anyway.

164
00:06:43,030 --> 00:06:47,180
Alright, so JDK 11 and OpenJDK
would be my recommendations,

165
00:06:47,180 --> 00:06:48,240
but of course, as a developer,

166
00:06:48,240 --> 00:06:50,120
you can also use the OpenJDK,

167
00:06:50,120 --> 00:06:51,800
sorry, the Oracle JDK,

168
00:06:51,800 --> 00:06:54,080
quite confusing to keep
up with these terms,

169
00:06:54,080 --> 00:06:57,340
because you're a developer,
you're free to use that to test

170
00:06:57,340 --> 00:06:59,200
and develop your applications.

171
00:06:59,200 --> 00:07:02,960
Alright, so hope that's given
you some ideas and what to do,

172
00:07:02,960 --> 00:07:06,150
and I look forward to talking
to you in another video.

173
00:07:06,150 --> 00:07:07,300
Alright, so thanks for watching,

174
00:07:07,300 --> 00:07:09,120
if you've got questions, leave a comment.

175
00:07:09,120 --> 00:07:11,480
If you're ready for the next
programming specific video,

176
00:07:11,480 --> 00:07:12,520
click on the link up here

177
00:07:12,520 --> 00:07:14,430
in the top left-hand
corner of your screen.

178
00:07:14,430 --> 00:07:16,910
To look at non-coding,
program-related questions,

179
00:07:16,910 --> 00:07:17,743
click on the link down

180
00:07:17,743 --> 00:07:19,370
in the bottom left-hand
corner of your screen.

181
00:07:19,370 --> 00:07:22,220
Feel free to subscribe by
clicking on the link up here,

182
00:07:22,220 --> 00:07:23,920
and I'll see you in another video.
```