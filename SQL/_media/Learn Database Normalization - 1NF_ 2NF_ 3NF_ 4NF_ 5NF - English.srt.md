```srt
1
00:00:00,160 --> 00:00:01,160
If you’ve had some exposure to relational 
databases, you’ve probably come across the term  

2
00:00:05,040 --> 00:00:06,040
“normalization”. But what is normalization? 
Why do we do it? How do we do it? And what  

3
00:00:12,000 --> 00:00:13,000
bad things can happen if we don’t do it?
In this video, we’re going to explore database  

4
00:00:18,240 --> 00:00:19,240
normalization from a practical perspective. 
We’ll keep the jargon to a minimum,  

5
00:00:23,600 --> 00:00:24,600
and we’ll use lots of examples as we go. By the 
end of it, you’ll understand the so-called normal  

6
00:00:29,280 --> 00:00:30,280
forms from First Normal Form all the way up to 
Fifth Normal Form – and you’ll have a clear sense  

7
00:00:35,280 --> 00:00:36,280
of what we gain by doing normalization, 
and what we lose by failing to do it.
 

8
00:00:41,280 --> 00:00:42,280
This is Decomplexify, bringing a welcome 
dose of simplicity to complex topics.
 

9
00:00:48,000 --> 00:00:49,000
Data: it’s everywhere. And some of it is wrong.
 

10
00:00:54,480 --> 00:00:55,480
By and large, even a good database 
design can’t protect against bad data.  

11
00:00:59,760 --> 00:01:00,760
But there are some cases of bad data that a good 
database design can protect against. These are  

12
00:01:05,280 --> 00:01:06,280
cases where the data is telling us something 
that logically cannot possibly be true:
 

13
00:01:12,800 --> 00:01:13,800
One customer with two dates of birth is 
logically impossible. It’s what we might  

14
00:01:17,680 --> 00:01:18,680
call a failure of data integrity. The data can’t 
be trusted because it disagrees with itself. 
 

15
00:01:24,880 --> 00:01:25,880
When data disagrees with itself, that’s 
more than just a problem of bad data.  

16
00:01:29,440 --> 00:01:30,440
It’s a problem of bad database design.  

17
00:01:32,480 --> 00:01:33,480
Specifically, it’s what happens when a 
database design isn’t properly normalized. 
 

18
00:01:38,560 --> 00:01:39,560
So what does normalization mean? 
When you normalize a database table,  

19
00:01:43,680 --> 00:01:44,680
you structure it in such a way that 
can’t express redundant information.  

20
00:01:48,720 --> 00:01:49,720
So, for example, in a normalized table, you 
wouldn’t be able to give Customer 1001 two dates  

21
00:01:54,880 --> 00:01:55,880
of birth even if you wanted to. Very broadly, the 
table can only express one version of the truth.
 

22
00:02:03,600 --> 00:02:04,600
Normalized database tables are not only 
protected from contradictory data, they’re also:
 

23
00:02:08,640 --> 00:02:09,640
easier to understand
easier to enhance and extend
 

24
00:02:14,160 --> 00:02:15,160
protected from insertion 
anomalies, update anomalies,  

25
00:02:18,000 --> 00:02:19,000
and deletion anomalies (more on these later)
 

26
00:02:23,120 --> 00:02:24,120
How do we determine whether a table isn’t 
normalized enough – in other words, how do  

27
00:02:27,920 --> 00:02:28,920
we determine if there’s a danger that redundant 
data could creep into the table? Well, it turns  

28
00:02:34,320 --> 00:02:35,320
out that there are sets of criteria we can use to 
assess the level of danger. These sets of criteria  

29
00:02:40,800 --> 00:02:41,800
have names like “first normal form”, “second 
normal form”, “third normal form”, and so on.
 

30
00:02:47,920 --> 00:02:48,920
Think of these normal forms by analogy to safety 
assessments. We might imagine an engineer doing a  

31
00:02:54,240 --> 00:02:55,240
very basic safety assessment on a bridge. Let’s 
say the bridge passes the basic assessment,  

32
00:03:00,080 --> 00:03:01,080
which means it achieves “Safety Level 
1: Safe for Pedestrian Traffic”.  

33
00:03:05,360 --> 00:03:06,360
That gives us some comfort, but suppose we want to 
know if cars can safely drive across the bridge?  

34
00:03:11,120 --> 00:03:12,120
To answer that question, we need the engineer to 
perform an even stricter assessment of the bridge.  

35
00:03:16,720 --> 00:03:17,720
Let’s imagine that the engineer goes ahead and 
does this stricter assessment, and again the  

36
00:03:21,360 --> 00:03:22,360
bridge passes, achieving “Safety Level 2: Safe 
for Cars”. If even this doesn’t satisfy us,  

37
00:03:27,600 --> 00:03:28,600
we might ask the engineer to assess the bridge 
for “Safety Level 3: Safe for Trucks.” And so on.
 

38
00:03:35,360 --> 00:03:36,360
The normal forms of database 
theory work the same way.  

39
00:03:39,040 --> 00:03:40,040
If we discover that a table meets the 
requirements of first normal form,  

40
00:03:43,520 --> 00:03:44,520
that’s a bare minimum safety guarantee. If 
we further discover that the table meets  

41
00:03:48,480 --> 00:03:49,480
the requirements of second normal form, that’s 
an even greater safety guarantee. And so on.
 

42
00:03:55,600 --> 00:03:56,600
So let’s begin at the beginning, 
with First Normal Form.
 

43
00:03:59,280 --> 00:04:00,280
Suppose you and I are both 
confronted by this question: 
 

44
00:04:02,000 --> 00:04:03,000
“Who were the members of the Beatles?” 
You might answer “John, Paul, George, and Ringo”.  

45
00:04:08,240 --> 00:04:09,240
I might answer “Paul, John, Ringo, and George”.
Of course, my answer and your answer are  

46
00:04:14,880 --> 00:04:15,880
equivalent, despite having the 
names in a different order.
 

47
00:04:18,640 --> 00:04:19,640
When it comes to relational databases, the same 
principle applies. Let’s record the names of the  

48
00:04:23,840 --> 00:04:24,840
Beatles in a table, and then let’s ask the 
database to return those names back to us. 
 

49
00:04:30,640 --> 00:04:31,640
The results will get returned to us in an 
arbitrary order. For example, they might  

50
00:04:35,120 --> 00:04:36,120
get returned like this.
Or like this.
 

51
00:04:41,040 --> 00:04:42,040
Or in any other order. There is no “right” order.
Are there ever situations where there’s a right  

52
00:04:48,640 --> 00:04:49,640
order? Suppose we write down the members 
of the Beatles from tallest to shortest,  

53
00:04:53,520 --> 00:04:54,520
like this. We title our list “Members Of 
The Beatles From Tallest To Shortest”.
 

54
00:05:02,560 --> 00:05:03,560
In this list, it’s not just the names that 
convey meaning. The order of the names conveys  

55
00:05:06,960 --> 00:05:07,960
meaning too. Paul is the tallest, John is the 
second-tallest, and so on. Lists like this are  

56
00:05:12,880 --> 00:05:13,880
totally comprehensible to us – but they’re not 
normalized. Remember, there’s no such thing as row  

57
00:05:19,200 --> 00:05:20,200
order within a relational database table. So here 
we have our first violation of First Normal Form.  

58
00:05:25,520 --> 00:05:26,520
When we use row order to convey information, 
we’re violating First Normal Form. 
 

59
00:05:31,360 --> 00:05:32,360
The solution is very simple. Be explicit – if 
we want to capture height information, we should  

60
00:05:37,200 --> 00:05:38,200
devote a separate column to it – like this.
Or even better, like this.
 

61
00:05:45,840 --> 00:05:46,840
So far, we’ve seen one way in 
which a design can fail to achieve  

62
00:05:49,440 --> 00:05:50,440
First Normal Form. But there are others.
A second way of violating First Normal Form  

63
00:05:54,160 --> 00:05:55,160
involves mixing data types. Suppose our 
Beatle_Height dataset looked like this.
 

64
00:06:02,400 --> 00:06:03,400
If you’re accustomed to spreadsheets, you’ll be 
aware that they typically won’t stop you from  

65
00:06:06,400 --> 00:06:07,400
having more than one datatype within a single 
column – for example, they won’t stop you from  

66
00:06:11,280 --> 00:06:12,280
storing both numbers and strings in a column. But 
in a relational database, you’re not allowed to be  

67
00:06:17,280 --> 00:06:18,280
cagey or ambiguous about a column’s data type. 
The values that go in the Height_In_Cm column  

68
00:06:23,680 --> 00:06:24,680
can’t be a mix of integers and strings. Once you 
define Height_In_Cm as being an integer column,  

69
00:06:29,760 --> 00:06:30,760
then every value that goes into that column 
will be an integer – no strings, no timestamps,  

70
00:06:35,520 --> 00:06:36,520
no data types of any kind other than 
integers. So: mixing datatypes within a column  

71
00:06:41,440 --> 00:06:42,440
is a violation of First Normal Form, and in fact 
the database platform won’t even let you do it.
 

72
00:06:48,640 --> 00:06:49,640
A third way of violating First Normal Form is by 
designing a table without a primary key. A primary  

73
00:06:55,200 --> 00:06:56,200
key is a column, or combination of columns, 
that uniquely identifies a row in the table.  

74
00:07:01,440 --> 00:07:02,440
For example, in the table Beatle_Height, 
our intention is that each row should tell  

75
00:07:06,240 --> 00:07:07,240
us about one particular Beatle, so we ought to 
designate “Beatle” as the primary key of the  

76
00:07:11,920 --> 00:07:12,920
Beatle_Height table. The database platform will 
need to know about our choice of primary key,  

77
00:07:18,240 --> 00:07:19,240
so we’ll want to get the primary key into 
the database by doing something like this.
 

78
00:07:24,080 --> 00:07:25,080
With the primary key in place, the 
database platform will prevent multiple  

79
00:07:27,600 --> 00:07:28,600
rows for the same Beatle from ever 
being inserted. That’s a good thing,  

80
00:07:32,000 --> 00:07:33,000
because multiple rows for the same Beatle would 
be nonsensical, and perhaps contradictory.
 

81
00:07:38,000 --> 00:07:39,000
Obviously, a Beatle can’t have 
two different heights at once.
 

82
00:07:42,240 --> 00:07:43,240
Every table we design should have a primary key. 
If it doesn’t, it’s not in First Normal Form.
 

83
00:07:49,040 --> 00:07:50,040
The last way of failing to achieve 
First Normal Form involves the notion of  

84
00:07:52,880 --> 00:07:53,880
“repeating groups”. Suppose we’re designing 
a database for an online multiplayer game.  

85
00:07:58,640 --> 00:07:59,640
At a given time, each player has a number 
of items of different types, like arrows,  

86
00:08:02,960 --> 00:08:03,960
shields, and copper coins. We might 
represent the situation like this.
 

87
00:08:09,600 --> 00:08:10,600
A player’s inventory is what we call a “repeating 
group”. Each inventory contains potentially many  

88
00:08:15,360 --> 00:08:16,360
different types of items: arrows, shields, 
copper coins, and so on; and in fact there  

89
00:08:21,440 --> 00:08:22,440
may be hundreds of different types of items 
that a player might have in their inventory.
 

90
00:08:26,640 --> 00:08:27,640
We could design a database table that 
represents the Inventory as a string of text:
 

91
00:08:32,320 --> 00:08:33,320
But this is a terrible design because 
there’s no easy way of querying it.  

92
00:08:36,480 --> 00:08:37,480
For example, if we want to know which players 
currently have more than 10 copper coins,  

93
00:08:41,680 --> 00:08:42,680
then having the inventory data 
lumped together in a text string  

94
00:08:45,120 --> 00:08:46,120
will make it very impractical to write 
a query that gives us the answer.
 

95
00:08:50,640 --> 00:08:51,640
We might be tempted to 
represent the data like this.
 

96
00:08:54,400 --> 00:08:55,400
This lets us record up to 4 items per inventory. 
But given that a player can have an inventory  

97
00:09:00,400 --> 00:09:01,400
consisting of hundreds of different types of 
items, how practical is it going to be to design  

98
00:09:04,960 --> 00:09:05,960
a table with hundreds of columns? Even if we were 
to go ahead and create a super-wide table to hold  

99
00:09:10,880 --> 00:09:11,880
all possible inventory data, querying 
it would still be extremely awkward.
 

100
00:09:16,320 --> 00:09:17,320
The bottom line is that storing a repeating group 
of data items on a single row violates First  

101
00:09:21,760 --> 00:09:22,760
Normal Form. So what sort of alternative 
design would respect First Normal Form?  

102
00:09:28,000 --> 00:09:29,000
It would be this.
To communicate the fact that  

103
00:09:32,000 --> 00:09:33,000
trev73 owns 3 shields, we have a row for Player 
“trev73”, Item_Type “shields”, Item_Quantity 3.  

104
00:09:39,680 --> 00:09:40,680
To communicate the fact that 
trev73 also owns 5 arrows,  

105
00:09:43,360 --> 00:09:44,360
we have a row for Player “trev73”, Item_Type 
“arrows”, Item_Quantity 5. And so on.
 

106
00:09:49,920 --> 00:09:50,920
And because each row in the table tells 
us about one unique combination of Player  

107
00:09:54,480 --> 00:09:55,480
and Item_Type, the primary key is the 
combination of Player and Item_Type.
 

108
00:10:00,320 --> 00:10:01,320
So let’s review what we know 
about First Normal Form.
 

109
00:10:04,000 --> 00:10:05,000
1. using row order to convey 
information is not permitted
 

110
00:10:08,880 --> 00:10:09,880
2. mixing data types within the 
same column is not permitted
 

111
00:10:13,360 --> 00:10:14,360
3. having a table without a 
primary key is not permitted
 

112
00:10:17,520 --> 00:10:18,520
4. repeating groups are not permitted
Next up: Second Normal Form.  

113
00:10:25,200 --> 00:10:26,200
Let’s look again at our Player Inventory table.
This table is fully normalized. But suppose we  

114
00:10:32,880 --> 00:10:33,880
enhance the table slightly. Let’s imagine 
that every player has a rating: Beginner,  

115
00:10:37,760 --> 00:10:38,760
Intermediate, or Advanced. We want to record the 
current rating of each player – and to achieve  

116
00:10:43,520 --> 00:10:44,520
that, we simply include in our table 
an extra column called Player_Rating.
 

117
00:10:49,840 --> 00:10:50,840
Notice what’s happening here. Player 
jdog21 has a Player_Rating of Intermediate,  

118
00:10:55,440 --> 00:10:56,440
but because jdog21 has two rows in the table, 
both those rows have to be marked Intermediate.  

119
00:11:01,600 --> 00:11:02,600
Player trev73 has a Player_Rating of Advanced,  

120
00:11:05,120 --> 00:11:06,120
but because trev73 has four rows in the table, all 
four of those rows have to be marked Advanced.
 

121
00:11:11,920 --> 00:11:12,920
This is not a good design. Why not? Well, 
suppose player gila19 loses all her copper coins,  

122
00:11:19,760 --> 00:11:20,760
leaving her with nothing in her inventory. 
The single entry that she did have in the  

123
00:11:24,160 --> 00:11:25,160
Player_Inventory table is now gone.
If we try to query the database to find  

124
00:11:30,480 --> 00:11:31,480
out what gila19’s Player Rating is, we’re out 
of luck. We can no longer access gila19’s Player  

125
00:11:36,560 --> 00:11:37,560
Rating because the database no longer knows it. 
This problem is known as a deletion anomaly.
 

126
00:11:43,200 --> 00:11:44,200
And that’s not all. Suppose jdog21 improves 
his rating from Intermediate to Advanced.  

127
00:11:49,440 --> 00:11:50,440
To capture his new Advanced rating 
in the Player_Inventory table,  

128
00:11:53,200 --> 00:11:54,200
we run an update on his two records. 
But let’s imagine the update goes wrong.  

129
00:11:59,840 --> 00:12:00,840
By accident, only one of jdog21’s records gets 
updated, and the other record gets left alone.  

130
00:12:06,400 --> 00:12:07,400
Now the data looks like this.
As far as the database is concerned,  

131
00:12:11,280 --> 00:12:12,280
jdog21 is somehow both Intermediate 
and Advanced at the same time.  

132
00:12:16,160 --> 00:12:17,160
Our table design has left the door open 
for this type of logical inconsistency.  

133
00:12:20,720 --> 00:12:21,720
This problem is called an update anomaly. 
Or suppose a new player called tina42 comes along.  

134
00:12:27,680 --> 00:12:28,680
She’s a Beginner and she doesn’t have anything 
in her inventory yet. We want to record the fact  

135
00:12:32,800 --> 00:12:33,800
that she’s a Beginner, but because she 
has nothing in her inventory, we can’t  

136
00:12:37,040 --> 00:12:38,040
insert a tina42 row into the Player_Inventory 
table. So her rating goes unrecorded. This  

137
00:12:42,960 --> 00:12:43,960
problem is known as an insertion anomaly.
The reason our design is vulnerable to these  

138
00:12:49,360 --> 00:12:50,360
problems is that it isn’t in Second Normal 
Form. Why not? What is Second Normal Form? 
 

139
00:12:56,720 --> 00:12:57,720
Second Normal Form is about how a table’s non-key 
columns relate to the primary key. In our table,  

140
00:13:02,960 --> 00:13:03,960
the non-key columns – or to use slightly 
different terminology, non-key attributes – are  

141
00:13:08,960 --> 00:13:09,960
Item_Quantity and Player_Rating. They are columns 
(also called attributes), that don’t belong  

142
00:13:15,360 --> 00:13:16,360
to the primary key. As we saw earlier, the primary 
key is the combination of Player and Item Type.
 

143
00:13:22,080 --> 00:13:23,080
Now we’re in a position to give a 
definition of Second Normal Form.  

144
00:13:25,920 --> 00:13:26,920
The definition we’re going to give is 
an informal one which leaves out some  

145
00:13:29,600 --> 00:13:30,600
nuances – but for most practical 
purposes, that shouldn’t matter.  

146
00:13:34,400 --> 00:13:35,400
Informally, what Second Normal Form says 
is that each non-key attribute in the table  

147
00:13:38,960 --> 00:13:39,960
must be dependent on the entire primary key. 
How does our table measure up to this definition?  

148
00:13:45,760 --> 00:13:46,760
Let’s examine our non-key attributes, which are 
the attributes Item_Quantity and Player_Rating.  

149
00:13:51,680 --> 00:13:52,680
Does Item_Quantity depend on the entire primary 
key? Yes, because an Item_Quantity is about a  

150
00:13:57,120 --> 00:13:58,120
specific Item_Type owned by specific 
Player. We can express it like this.
 

151
00:14:03,040 --> 00:14:04,040
The arrow signifies a dependency – or to give 
it its proper name, a functional dependency.  

152
00:14:08,640 --> 00:14:09,640
This simply means that each value of the thing 
on the left side of the arrow is associated with  

153
00:14:13,280 --> 00:14:14,280
exactly one value of the thing on the right side 
of the arrow. Each combination of Player_ID and  

154
00:14:18,800 --> 00:14:19,800
Item_Type is associated with a specific value 
of Item_Quantity – for example the combination  

155
00:14:25,120 --> 00:14:26,120
of Player_ID jdog21 / Item_Type “amulets” 
is associated with an Item_Quantity of 2.
 

156
00:14:31,440 --> 00:14:32,440
As far as Second Normal Form is 
concerned, this dependency is fine,  

157
00:14:34,880 --> 00:14:35,880
because it’s a dependency on the entire primary 
key. But what about the other dependency?
 

158
00:14:40,880 --> 00:14:41,880
Does Player_Rating depend on the entire primary 
key? No, it doesn’t. Player_Rating is a property  

159
00:14:46,640 --> 00:14:47,640
of the Player only. In other words, for any 
given Player, there’s one Player_Rating. 
 

160
00:14:52,800 --> 00:14:53,800
This dependency on Player is the problem. 
It’s a problem because Player isn’t the  

161
00:14:58,080 --> 00:14:59,080
primary key – Player is part of the 
primary key, but it’s not the whole key.  

162
00:15:02,800 --> 00:15:03,800
That’s why the table isn’t in Second Normal Form, 
and that’s why it’s vulnerable to problems.
 

163
00:15:08,880 --> 00:15:09,880
At what point did our design go wrong, and 
how can we fix it? The design went wrong  

164
00:15:13,840 --> 00:15:14,840
when we chose to add a Player_Rating column 
to a table where it didn’t really belong.  

165
00:15:18,480 --> 00:15:19,480
The fact that a Player_Rating is a property 
of a Player should have helped us to realise  

166
00:15:22,560 --> 00:15:23,560
that a Player is an important concept in its own 
right – so surely Player deserves its own table:
 

167
00:15:29,840 --> 00:15:30,840
Nothing could be simpler than that. A Player 
table will contain one row per Player,  

168
00:15:34,400 --> 00:15:35,400
and in it we can include as columns the ID of 
the player, the rating of the player, as well  

169
00:15:39,280 --> 00:15:40,280
as all sorts of other properties of the player 
– maybe the player’s date of birth, for example,  

170
00:15:43,520 --> 00:15:44,520
maybe the player’s email address. Our other 
table, Player_Inventory, can stay as it was.
 

171
00:15:50,720 --> 00:15:51,720
For both tables, we can say that 
there are no part-key dependencies.  

172
00:15:54,880 --> 00:15:55,880
In other words, it’s always the case that every 
attribute depends on the whole primary key,  

173
00:15:59,440 --> 00:16:00,440
not just part of it. And so our 
tables are in Second Normal Form.
 

174
00:16:06,160 --> 00:16:07,160
Now let’s move on to Third Normal Form. 
Suppose we decide to enhance the Player table.
 

175
00:16:12,080 --> 00:16:13,080
We decide to add a new column 
called Player_Skill_Level.
 

176
00:16:16,880 --> 00:16:17,880
Imagine that in this particular multiplayer 
game, there’s a nine-point scale for skill level.  

177
00:16:22,080 --> 00:16:23,080
At one extreme, a player with skill 
level 1 is an absolute beginner;  

178
00:16:25,440 --> 00:16:26,440
at the opposite extreme, a player with skill 
level 9 is as skilful as it’s possible to be.  

179
00:16:30,720 --> 00:16:31,720
And let’s say that we’ve defined exactly how 
Player Skill Levels relate to Player Ratings.  

180
00:16:36,160 --> 00:16:37,160
“Beginner” means a skill level between 
1 and 3. “Intermediate” means a skill  

181
00:16:40,160 --> 00:16:41,160
level between 4 and 6. And “Advanced” 
means a skill level between 7 and 9.
 

182
00:16:46,640 --> 00:16:47,640
But now that both the Player_Rating and the 
Player_Skill_Level exist in the Player table,  

183
00:16:51,040 --> 00:16:52,040
a problem can arise. Let’s say that tomorrow, 
player gila19’s skill level increases from 3  

184
00:16:56,800 --> 00:16:57,800
to 4. If that happens, we’ll update her row in the 
Player table to reflect this new skill level. 
 

185
00:17:04,960 --> 00:17:05,960
By rights, we should also update her Player_Rating 
to Intermediate – but suppose something goes  

186
00:17:10,000 --> 00:17:11,000
wrong, and we fail to update the Player_Rating. 
Now we’ve got a data inconsistency. gila19’s  

187
00:17:15,840 --> 00:17:16,840
Player_Rating says she’s a Beginner, but her 
Player_Skill_Level implies she’s Intermediate.
 

188
00:17:22,000 --> 00:17:23,000
How did the design allow this happen? Second 
Normal Form didn’t flag up any problems. There’s  

189
00:17:27,440 --> 00:17:28,440
no attribute here that depends only partially 
on the primary key – as a matter of fact,  

190
00:17:31,840 --> 00:17:32,840
the primary key doesn’t have any parts; it’s 
just a single attribute. And both Player_Rating  

191
00:17:37,120 --> 00:17:38,120
and Player_Skill_Level are dependent on it.
But in what way are they dependent on it? Let’s  

192
00:17:42,960 --> 00:17:43,960
look more closely. Player_Skill_Level 
is dependent on Player_ID.
 

193
00:17:48,480 --> 00:17:49,480
Player_Rating is dependent on Player ID 
too, but only indirectly – like this.
 

194
00:17:54,560 --> 00:17:55,560
A dependency of this kind is called a transitive 
dependency. Player Rating depends on Player Skill  

195
00:18:00,400 --> 00:18:01,400
Level which in turn depends on the primary 
key: Player ID. The problem is located just  

196
00:18:07,040 --> 00:18:08,040
here – because what Third Normal Form forbids is 
exactly this type of dependency: the dependency of  

197
00:18:13,600 --> 00:18:14,600
a non-key attribute on another non-key attribute.
Because Player Rating depends on Player Skill  

198
00:18:21,120 --> 00:18:22,120
Level – which is a non-key attribute – 
this table is not in Third Normal Form.
 

199
00:18:26,560 --> 00:18:27,560
There’s a very simple way of repairing the 
design to get it into Third Normal Form.  

200
00:18:30,880 --> 00:18:31,880
We remove Player Rating from the Player table; 
so now the Player table looks like this.
 

201
00:18:35,920 --> 00:18:36,920
And we introduce a new table 
called Player_Skill_Levels.
 

202
00:18:40,240 --> 00:18:41,240
The Player Skill Levels table tells us everything 
we need to know about how to translate a player  

203
00:18:44,560 --> 00:18:45,560
skill level into a player rating.
Third Normal Form is the culmination of everything  

204
00:18:49,760 --> 00:18:50,760
we’ve covered about database normalization so 
far. It can be summarised in this way: Every  

205
00:18:55,200 --> 00:18:56,200
non-key attribute in a table should depend on 
the key, the whole key, and nothing but the key.  

206
00:19:01,600 --> 00:19:02,600
If you commit this to memory, and keep it 
constantly in mind while you’re designing a  

207
00:19:05,440 --> 00:19:06,440
database, then 99% of the time you will 
end up with fully normalized tables. 
 

208
00:19:12,080 --> 00:19:13,080
It’s even possible to shorten this guideline 
slightly by knocking out the phrase  

209
00:19:15,680 --> 00:19:16,680
“non-key” – giving us the revised guideline: every 
attribute in a table should depend on the key, the  

210
00:19:21,680 --> 00:19:22,680
whole key, and nothing but the key. And this new 
guideline represents a slightly stronger flavor of  

211
00:19:27,440 --> 00:19:28,440
Third Normal Form known as Boyce-Codd Normal Form. 
In practice, the difference between Third Normal  

212
00:19:33,200 --> 00:19:34,200
Form and Boyce-Codd Normal Form is extremely 
small, and the chances of you ever encountering  

213
00:19:39,440 --> 00:19:40,440
a real-life Third Normal Form table that doesn’t 
meet Boyce-Codd Normal Form are almost zero.  

214
00:19:45,120 --> 00:19:46,120
Any such table would have to have what we call 
multiple overlapping candidate keys – which gets  

215
00:19:50,480 --> 00:19:51,480
us into realms of obscurity and theoretical 
rigor that are a little bit beyond the scope  

216
00:19:55,280 --> 00:19:56,280
of this video. So as a practical matter, just 
follow the guideline that every attribute in a  

217
00:20:00,720 --> 00:20:01,720
table should depend on the key, the whole 
key, and nothing but the key, and you can  

218
00:20:05,200 --> 00:20:06,200
be confident that the table will be in both 
Third Normal Form and Boyce-Codd Normal Form.
 

219
00:20:13,280 --> 00:20:14,280
In almost all cases, once you’ve normalized 
a table this far, you’ve fully normalized  

220
00:20:17,920 --> 00:20:18,920
it. There are some instances where this 
level of normalization isn’t enough.  

221
00:20:22,480 --> 00:20:23,480
These rare instances are dealt with 
by Fourth and Fifth Normal Form.
 

222
00:20:27,040 --> 00:20:28,040
So let’s move on to Fourth Normal Form. We’ll 
look at an example of a situation where Third  

223
00:20:32,320 --> 00:20:33,320
Normal Form isn’t quite good enough and something 
a bit stronger is needed. In our example, there’s  

224
00:20:37,600 --> 00:20:38,600
a website called DesignMyBirdhouse.com – the 
world’s leading supplier of customized birdhouses.  

225
00:20:44,080 --> 00:20:45,080
On DesignMyBirdhouse.com, customers can 
choose from different birdhouse models,  

226
00:20:49,520 --> 00:20:50,520
and, for the model they’ve selected, 
they can choose both a custom color  

227
00:20:53,040 --> 00:20:54,040
and a custom style. Each model has its 
own range of available colors and styles.
 

228
00:21:00,000 --> 00:21:01,000
One way of capturing this information 
is to put it all the possible  

229
00:21:02,960 --> 00:21:03,960
combinations in a single table, like this.
This table is in Third Normal Form. The primary  

230
00:21:10,960 --> 00:21:11,960
key consists of all three columns: {Model, 
Color, Style}. Everything depends on the key,  

231
00:21:16,480 --> 00:21:17,480
the whole key, and nothing but the key.
And yet this table is still vulnerable  

232
00:21:21,840 --> 00:21:22,840
to problems. Let’s look at the rows 
for the birdhouse model “Prairie”:
 

233
00:21:27,600 --> 00:21:28,600
The available colors for the “Prairie” 
birdhouse model are brown and beige.  

234
00:21:32,080 --> 00:21:33,080
Now suppose DesignMyBirdhouse.com decides 
to introduce a third available color for  

235
00:21:36,880 --> 00:21:37,880
the “Prairie” model: green. This will mean we’ll 
have to add two extra “Prairie” rows to the table:  

236
00:21:44,160 --> 00:21:45,160
one for green bungalow, and 
one for green schoolhouse. 
 

237
00:21:49,600 --> 00:21:50,600
If by mistake we only add a row for green 
bungalow, and fail to add the row for green  

238
00:21:53,920 --> 00:21:54,920
schoolhouse, then we have a data inconsistency.
Available colors are supposed to be completely  

239
00:22:00,720 --> 00:22:01,720
independent of available styles. But our 
table is saying that a customer can choose  

240
00:22:05,200 --> 00:22:06,200
green only for the bungalow style, not for 
the schoolhouse style. That makes no sense.  

241
00:22:11,120 --> 00:22:12,120
The prairie birdhouse model is available in green, 
so all its styles should be available in green.  

242
00:22:16,800 --> 00:22:17,800
Something about the way the table is designed has 
allowed us to represent an impossible situation.
 

243
00:22:22,640 --> 00:22:23,640
To see what’s gone wrong, let’s have a 
closer look at the dependencies among Models,  

244
00:22:26,960 --> 00:22:27,960
Colors, and styles. Can we say that Color 
has a functional dependency on Model?  

245
00:22:33,120 --> 00:22:34,120
Actually no, because a specific Model 
isn’t associated with just one Color. 
 

246
00:22:38,320 --> 00:22:39,320
And yet it does feel as though Color has some 
relationship to Model. How can we express it?  

247
00:22:44,400 --> 00:22:45,400
We can say that each Model has a specific set 
of available Colors. This kind of dependency is  

248
00:22:50,080 --> 00:22:51,080
called a multivalued dependency, and we express 
it with a double-headed arrow, like this:
 

249
00:22:58,240 --> 00:22:59,240
And it’s equally true that each Model 
has a specific set of available Styles.
 

250
00:23:04,000 --> 00:23:05,000
What Fourth Normal Form says is that the only 
kinds of multivalued dependency we’re allowed  

251
00:23:08,640 --> 00:23:09,640
to have in a table are multivalued dependencies 
on the key. Model is not the key; so the table  

252
00:23:15,520 --> 00:23:16,520
Model_Colors_And_Styles_Available 
is not in Fourth Normal Form.
 

253
00:23:20,800 --> 00:23:21,800
As always, the fix is to split 
things out into multiple tables.
 

254
00:23:26,560 --> 00:23:27,560
Now, if DesignMyBirdhouse.com expands the range of 
Prairie-Model colors to include green, we simply  

255
00:23:32,800 --> 00:23:33,800
add a row to the Model_Colors_Available table:
And no anomalies are possible.
 

256
00:23:42,000 --> 00:23:43,000
We’re now ready for Fifth Normal Form, the 
last normal form covered in this video. 
 

257
00:23:48,320 --> 00:23:49,320
For our Fifth Normal Form example, we imagine 
that there are three different brands of ice  

258
00:23:52,400 --> 00:23:53,400
cream available: Frosty’s, Alpine, and Ice 
Queen. Each of the three brands of ice cream  

259
00:23:58,640 --> 00:23:59,640
offers a different range of flavors:
Frosty’s offers vanilla, chocolate,  

260
00:24:03,120 --> 00:24:04,120
strawberry, and mint chocolate chip
Alpine offers vanilla and rum raisin
 

261
00:24:08,400 --> 00:24:09,400
Ice Queen offers vanilla, 
strawberry, and mint chocolate chip
 

262
00:24:13,040 --> 00:24:14,040
Now we ask our friend Jason what 
types of ice cream he likes.  

263
00:24:16,560 --> 00:24:17,560
Jason says: I only like vanilla and chocolate. 
And I only like the brands Frosty and Alpine.
 

264
00:24:24,560 --> 00:24:25,560
We ask our other friend, Suzy, what types of 
ice cream she likes. Suzy says: I only like  

265
00:24:30,000 --> 00:24:31,000
rum raisin, mint chocolate chip, and strawberry. 
And I only like the brands Alpine and Ice Queen.
 

266
00:24:37,760 --> 00:24:38,760
So, after a little bit of brainwork, we 
deduce exactly which ice cream products  

267
00:24:41,920 --> 00:24:42,920
Jason and Suzy are willing to eat; 
and we express this in a table:
 

268
00:24:48,720 --> 00:24:49,720
But time passes, tastes change, and at some point 
Suzy announces that she now likes Frosty’s brand  

269
00:24:54,720 --> 00:24:55,720
ice cream too. So we need to update our table.
It won’t come as any surprise that we might get  

270
00:25:03,040 --> 00:25:04,040
this update wrong. We might successfully add a 
row for Person Suzy – Brand Frosty’s – Flavor  

271
00:25:09,040 --> 00:25:10,040
Strawberry, but fail to add a row for Person Suzy 
– Brand Frosty’s – Flavor Mint Chocolate Chip.  

272
00:25:15,680 --> 00:25:16,680
And this outcome wouldn’t just be wrong – it 
would be logically inconsistent – because we’ve  

273
00:25:20,960 --> 00:25:21,960
already established that Suzy likes Frosty’s 
brand, and likes Mint Chocolate Chip flavor,  

274
00:25:26,160 --> 00:25:27,160
and therefore there’s no way she can 
dislike Frosty’s Mint Chocolate Chip.
 

275
00:25:32,000 --> 00:25:33,000
In this example, we went wrong right at the 
beginning. At the beginning, we were given  

276
00:25:36,800 --> 00:25:37,800
three pieces of information. First, we were told 
which brands offered which flavors. Second, we  

277
00:25:42,480 --> 00:25:43,480
were told which people liked which brands. Third, 
we were told which people liked which flavors.  

278
00:25:49,280 --> 00:25:50,280
From those three pieces of information, we 
should have simply created three tables.
 

279
00:25:56,800 --> 00:25:57,800
And that’s all we needed to do. All the 
facts of the situation have been represented.  

280
00:26:02,000 --> 00:26:03,000
If we ever want to know what 
specific products everyone likes,  

281
00:26:05,200 --> 00:26:06,200
we can simply ask the database platform, 
expressing our question in the form of a  

282
00:26:10,160 --> 00:26:11,160
piece of SQL that logically deduces the 
answer by joining the tables together.
 

283
00:26:17,040 --> 00:26:18,040
To sum things up: if we want to ensure 
that a table that’s in Fourth Normal  

284
00:26:21,440 --> 00:26:22,440
Form is also in Fifth Normal Form, we need 
to ask ourselves whether the table can be  

285
00:26:26,160 --> 00:26:27,160
logically thought of as being the result 
of joining some other tables together.  

286
00:26:31,920 --> 00:26:32,920
If it can be thought of that way, 
then it’s not in Fifth Normal Form.  

287
00:26:36,640 --> 00:26:37,640
If it can’t be thought of that way, 
then it is in Fifth Normal Form.
 

288
00:26:42,160 --> 00:26:43,160
We’ve now covered all the normal forms from First 
Normal Form to Fifth Normal Form. Let’s review,  

289
00:26:49,360 --> 00:26:50,360
keeping in mind that for a table to comply with 
a particular normal form, it must comply with  

290
00:26:54,480 --> 00:26:55,480
all the lower normal forms as well.
The rules for first normal form are:
 

291
00:27:00,160 --> 00:27:01,160
1. using row order to convey 
information is not permitted
 

292
00:27:04,320 --> 00:27:05,320
2. mixing data types within the 
same column is not permitted
 

293
00:27:08,320 --> 00:27:09,320
3. having a table without a 
primary key is not permitted
 

294
00:27:12,640 --> 00:27:13,640
4. repeating groups are not permitted
The rule for second normal form is:  

295
00:27:19,520 --> 00:27:20,520
Each non-key attribute in the table must 
be dependent on the entire primary key. 
 

296
00:27:25,440 --> 00:27:26,440
The rule for third normal form is: Each non-key 
attribute in a table must depend on the key,  

297
00:27:30,800 --> 00:27:31,800
the whole key, and nothing but the key. If we 
prefer to drop the phrase “non-key”, we end up  

298
00:27:37,440 --> 00:27:38,440
with an even simpler and even stronger version of 
third normal form called “Boyce-Codd Normal Form”:  

299
00:27:43,200 --> 00:27:44,200
Each attribute in a table must depend on the 
key, the whole key, and nothing but the key. 
 

300
00:27:49,280 --> 00:27:50,280
The rule for fourth normal form is that 
the only kinds of multivalued dependency  

301
00:27:54,000 --> 00:27:55,000
we’re allowed to have in a table are 
multivalued dependencies on the key.
 

302
00:27:59,760 --> 00:28:00,760
Finally, the rule for Fifth Normal Form 
is: it must not be possible to describe  

303
00:28:04,720 --> 00:28:05,720
the table as being the logical result 
of joining some other tables together.
 

304
00:28:11,040 --> 00:28:12,040
I hope you’ve found this video helpful. 
If you have any comments or questions  

305
00:28:14,960 --> 00:28:15,960
on what you’ve just seen, by all means 
put them in the comments section below.  

306
00:28:19,760 --> 00:28:20,760
And if you have any suggestions for other 
complex topics that you’d like to see explained  

307
00:28:24,240 --> 00:28:25,240
on Decomplexify, again let me know in the 
comments. So long, and thanks for watching!
```