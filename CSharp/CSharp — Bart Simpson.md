---
tags:
- CSharp
date: 2019-08-28
---

# Bart Simpson

Di opening The simpson season berapa gitu, Bart dikasi tugas uat nulis di papan tulis soal kelakuannya 🤣.

```c#
public void Run() {
    for (Int32 i = 0; i < 30; i++)
        Console.WriteLine(RandomBartSimpsonChalkboardPunisment());
}

#region : Bart Simpson Chalkboard Punisment :

public static String RandomBartSimpsonChalkboardPunisment() {
    IList<String> punismentList = BartSimpsonChalkboardPunisment().ToList();
    return punismentList[punismentList.Count.Ryandomize()];
}

public static IEnumerable<String> BartSimpsonChalkboardPunisment() {
    yield return "'Bart Bucks' are not legal tender.";
    yield return "'Bewitched' does not promote Satanism.";
    yield return "'butt.com' is not my e-mail address.";
    yield return "'Caucus' is not a dirty word.";
    yield return "'Daylight Savings' Is Not a Failed Bank.";
    yield return "'Bagman' is not a legitimate career choice.";
    yield return "20 more shoplifting days till Christmas.";
    yield return "25 years and they can't come up with a new punishment.";
    yield return "A baby beat me up.";
    yield return "A belch is not an oral report.";
    yield return "A booger is not a bookmark.";
    yield return "A burp in a jar is not a science project.";
    yield return "A burp is not an answer.";
    yield return "A Charlie Brown Thanksgiving is as good as A Charlie Brown Christmas.";
    yield return "A fire drill does not demand a fire.";
    yield return "A person's a person, no matter how Ralph.";
    yield return "A trained ape could not teach gym.";
    yield return "Adding 'just kidding' doesn't make it okay to insult the principal.";
    yield return "All work and no play makes Bart a dull boy.";
    yield return "All Work and No Play Makes Jack A Dull Boy.";
    yield return "April Showers do not bring Matt Lauers.";
    yield return "Bart's earned a day off.";
    yield return "Batman Is Not 'Nothing' Without His Utility Belt.";
    yield return "Beans are neither a fruit nor musical.";
    yield return "Beer in a milk carton is not milk.";
    yield return "Cafeteria trays are not toboggans.";
    yield return "Call your mother during the commercials.";
    yield return "Candy canes are not elf bones.";
    yield return "Chalkboarding is not torture.";
    yield return "Class clown is not a paid position.";
    yield return "Coffee is not for kids.";
    yield return "Cursive writing does not mean what I think it does.";
    yield return "Dodgeball stops at the gym door.";
    yield return "Does any kid still do this anymore?";
    yield return "During the episode, Skinner writes 'I ain't not a dorkus.'.";
    yield return "Eating my vegetables is not a Mother's Day present.";
    yield return "End of Lost: It was all the dog's dream. Watch Us.";
    yield return "Everyone is tired of that Richard Gere story.";
    yield return "Fire is not the cleanser.";
    yield return "Fish do not like coffee.";
    yield return "Five days is not too long to wait for a gun.";
    yield return "Four leaf clovers are not mutant freaks.";
    yield return "Frankincense is not a monster.";
    yield return "Fridays are not 'pants optional'.";
    yield return "Fun does not have a size.";
    yield return "Funny noises are not funny.";
    yield return "Garlic gum is not funny.";
    yield return "Genetics is not an excuse.";
    yield return "Global Warming did not eat my homework.";
    yield return "Goldfish don't bounce.";
    yield return "Grammar is not a time of waste.";
    yield return "Guinea Pigs Should Not Be Used As 'Guinea Pigs'.";
    yield return "Halloween doesn't kick Thanksgiving's ass.";
    yield return "Have a great summer, everyone.";
    yield return "HDTV is worth every cent.";
    yield return "High explosives and school don't mix.";
    yield return "Hillbillies are people too.";
    yield return "Hot dogs are not bookmarks.";
    yield return "I am not a 32 year old woman.";
    yield return "I am not a dentist.";
    yield return "I am not a FDIC-insured bank.";
    yield return "I am not a lean mean spitting machine.";
    yield return "I am not a licensed hairstylist.";
    yield return "I am not allergic to long division.";
    yield return "I am not authorized to fire substitute teachers.";
    yield return "I am not certified to remove asbestos.";
    yield return "I am not Charlie Brown on acid.";
    yield return "I am not deliciously saucy.";
    yield return "I am not delightfully saucy";
    yield return "I am not here on a fartball scholarship.";
    yield return "I am not licensed to do anything.";
    yield return "I am not my long-lost twin.";
    yield return "I am not smarter than the President.";
    yield return "I am not the acting president.";
    yield return "I am not the last Don.";
    yield return "I am not the new Dalai Lama.";
    yield return "I am not the reincarnation of Sammy Davis Jr.";
    yield return "I can't see dead people.";
    yield return "I cannot absolve sins.";
    yield return "I cannot hire a substitute student.";
    yield return "I did not invent Irish dancing.";
    yield return "I did not learn everything I need to know from kindergarten.";
    yield return "I did not see Elvis.";
    yield return "I did not see my teacher siphoning gas.";
    yield return "I did not see Teacher applying for welfare.";
    yield return "I did not win the Nobel Fart Prize.";
    yield return "I do not deserve a Mother's Day gift for being 'one badass mother'.";
    yield return "I do not have a cereal named after me.";
    yield return "I do not have diplomatic immunity.";
    yield return "I do not have power of attorney over first graders.";
    yield return "I do not have the hots for my mom.";
    yield return "I have neither been there nor done that.";
    yield return "I must not write all over the walls.";
    yield return "I no longer want my MTV.";
    yield return "I saw nothing unusual in the teacher's lounge.";
    yield return "I should not be twenty-one by now.";
    yield return "I want to secede but don't know which state I'm in.";
    yield return "I was not the inspiration for 'Kramer'.";
    yield return "I was not the sixth Beatle.";
    yield return "I was not touched 'there' by an angel.";
    yield return "I was told not to do this.";
    yield return "I wasn't nominated for Best Spoken Swear Word.";
    yield return "I will finish what I sta.";
    yield return "I will never lie about being cancelled again.";
    yield return "I will never win an Emmy.";
    yield return "I will not 'let the dogs out'.";
    yield return "I will not aim for the head.";
    yield return "I will not barf unless I'm sick.";
    yield return "I will not be a snickerpuss.";
    yield return "I will not belch the national anthem.";
    yield return "I will not bite the hand that feeds me Butterfingers.";
    yield return "I will not bribe Principal Skinner.";
    yield return "I will not bring sheep to class.";
    yield return "I will not burp in class.";
    yield return "I will not bury the new kid.";
    yield return "I will not buy a presidential pardon.";
    yield return "I will not call my teacher 'Hot Cakes'";
    yield return "I will not call my teacher 'Prancer' and 'Vixen'.";
    yield return "I will not call the principal 'spud head'.";
    yield return "I will not carve gods.";
    yield return "I will not celebrate meaningless milestones.";
    yield return "I will not charge admission to the bathroom.";
    yield return "I will not complain about the solution when I hear it.";
    yield return "I will not concede the election till Karl Rove gives me permission.";
    yield return "I will not conduct my own fire drills.";
    yield return "I will not create art from dung.";
    yield return "I will not cut corners.";
    yield return "I will not dance on anyone's grave.";
    yield return "I will not deface using hieroglyphics where possible.";
    yield return "I will not defame New Orleans.";
    yield return "I will not demand what I'm worth.";
    yield return "I will not dissect things unless instructed.";
    yield return "I will not do 'the dirty bird.'.";
    yield return "I will not do anything bad ever again.";
    yield return "I will not do that thing with my tongue.";
    yield return "I will not draw naked ladies in class.";
    yield return "I will not drive the principal's car.";
    yield return "I will not eat things for money.";
    yield return "I will not encourage others to fly.";
    yield return "I will not expose the ignorance of the faculty.";
    yield return "I will not fake rabies.";
    yield return "I will not fake seizures.";
    yield return "I will not fight the future.";
    yield return "I will not file frivolous lawsuits.";
    yield return "I will not flip the classroom upside down.";
    yield return "I will not flush evidence.";
    yield return "I will not get very far with this attitude.";
    yield return "I will not go near the kindergarten turtle.";
    yield return "I will not grease the monkey bars.";
    yield return "I will not hang donuts on my person.";
    yield return "I will not have fun with educational toys.";
    yield return "I will not hide behind the Fifth Amendment.";
    yield return "I will not hide the teacher's medication.";
    yield return "I will not hide the teacher's Prozac.";
    yield return "I will not illegally download this movie.";
    yield return "I will not instigate revolution.";
    yield return "I will not laminate dog doo.";
    yield return "I will not leak the plot of the movie.";
    yield return "I will not look up how much teacher makes.";
    yield return "I will not make flatulent noises in class.";
    yield return "I will not make fun of Cupid's dink.";
    yield return "I will not mess with the opening credits.";
    yield return "I will not mock Mrs. Dumbface.";
    yield return "I will not mock teacher's outdated cell phone.";
    yield return "I will not obey the voices in my head.";
    yield return "I will not pay my sister to do my punishment.";
    yield return "I will not plant subliminal messagore.";
    yield return "I will not pledge allegiance to Bart.";
    yield return "I will not prescribe medication.";
    yield return "I will not publish the principal's credit report.";
    yield return "I will not put hot sauce in the CPR dummy.";
    yield return "I will not re-transmit without the express permission of Major League Baseball.";
    yield return "I will not replace a candy heart with a frog's heart.";
    yield return "I will not ridicule teacher's Final Four bracket.";
    yield return "I will not say 'Springfield' just to get applause.";
    yield return "I will not scare the vice president.";
    yield return "I will not scream for ice cream.";
    yield return "I will not sell land in Florida.";
    yield return "I will not sell miracle cures.";
    yield return "I will not sell my kidney on eBay.";
    yield return "I will not sell school property.";
    yield return "I will not send lard through the mail.";
    yield return "I will not show off.";
    yield return "I will not skateboard in the halls.";
    yield return "I will not sleep through my education.";
    yield return "I will not snap bras.";
    yield return "I will not spank others.";
    yield return "I will not speculate on how hot my teacher used to be.";
    yield return "I will not spin the turtle.";
    yield return "I will not squeak chalk.";
    yield return "I will not strut around like I own the place.";
    yield return "I will not surprise the incontinent.";
    yield return "I will not teach others to fly.";
    yield return "I will not tease Fatty.";
    yield return "I will not torment the emotionally frail.";
    yield return "I will not trade pants with others.";
    yield return "I will not tweet as the principal's toilet.";
    yield return "I will not use abbrev.";
    yield return "I will Not use Permanet ink on the Chalkboard.";
    yield return "I will not wait 20 years to make another movie.";
    yield return "I will not waste chalk.";
    yield return "I will not wear white after Labor Day.";
    yield return "I will not whittle hall passes out of soap.";
    yield return "I will not Xerox my butt.";
    yield return "I will not yell 'Fire!' in a crowded classroom.";
    yield return "I will not yell 'She's Dead' during roll call";
    yield return "I will not.";
    yield return "I will obey Oscar campaign rules from now on.";
    yield return "I will only do this once a year.";
    yield return "I will only provide a urine sample when asked.";
    yield return "I will remember to take my medication.";
    yield return "I will return the seeing-eye dog.";
    yield return "I will stop asking when Santa goes to the bathroom.";
    yield return "I will stop phoning it in.";
    yield return "I will stop talking about the twelve inch pianist.";
    yield return "I won't not use no double negatives.";
    yield return "I'm not here on a Spitball scholar.";
    yield return "I'm so very tired.";
    yield return "I'm sorry I broke the blackboard.";
    yield return "Indian burns are not our cultural heritage.";
    yield return "It does not suck to be you (A reference to a Prozzäk song)";
    yield return "It's 'Facebook,' not 'Assbook.'.";
    yield return "It's not too early to speculate about the 2016 election.";
    yield return "It's November 6th. How come we're not airing a Halloween show?";
    yield return "It's potato, Not potatoe.";
    yield return "January is not Bart History Month.";
    yield return "Je ne parle pas français ('I do not speak French.').";
    yield return "Jesus is not mad. His birthday is on Christmas.";
    yield return "Jesus's last words were not 'TGIF'.";
    yield return "Judas Priest is not 'death metal'.";
    yield return "Loose teeth don't need my help.";
    yield return "Making Milhouse cry is not a science project.";
    yield return "March Madness' is not an excuse for missing school.";
    yield return "Milhouse did not test cootie positive.";
    yield return "Mud is not one of the 4 food groups.";
    yield return "My butt does not deserve a website.";
    yield return "My dad's already drunk for St. Patrick's.";
    yield return "My homework was not stolen by a one-armed man.";
    yield return "My mom is not dating Jerry Seinfeld.";
    yield return "My name is not 'Dr. Death'.";
    yield return "My name is not Dr. Death.";
    yield return "My pen is not a booger launcher.";
    yield return "My piggy bank is not entitled to TARP funds.";
    yield return "My school schedule does NOT include a bye week.";
    yield return "My suspension was not mutual.";
    yield return "Nerve gas is not a toy.";
    yield return "Network TV is not dead.";
    yield return "Next time it could be me on the scaffolding.";
    yield return "No one cares about my sciatica.";
    yield return "No one cares what my definition of 'is' is.";
    yield return "No one is interested in my underpants.";
    yield return "No one wants to hear from my armpits.";
    yield return "Nobody likes sunburn slappers.";
    yield return "Nobody reads these anymore.";
    yield return "Non-flammable is not a challenge.";
    yield return "NOTE: This was originally the first chalkboard gag.";
    yield return "Organ transplants are best left to the professionals.";
    yield return "Over forty & single is not funny.";
    yield return "Pain is not the cleanser.";
    yield return "Pearls are not oyster barf.";
    yield return "Pixel art is not real art.";
    yield return "Poking a dead raccoon is not research.";
    yield return "Pork is not a verb.";
    yield return "Prince is not the son of Martin Luther King.";
    yield return "Prosperity is just around the corner.";
    yield return "Ralph won't 'morph' if you squeeze him hard enough.";
    yield return "Reindeer meat does not taste like chicken.";
    yield return "Rocktober is not followed by Blowvember.";
    yield return "Rudolph the Red-Nosed Reindeer's red nose is not alcohol-related.";
    yield return "Sandwiches should not contain sand.";
    yield return "Science class should not end in tragedy.";
    yield return "Sherri does not 'got back'.";
    yield return "Shooting paintballs is not an art form.";
    yield return "Silly string is not a nasal spray.";
    yield return "Snowmen don't have carrot penises.";
    yield return "So long suckers.";
    yield return "South Park, we'd stand beside you if we weren't so scared.";
    yield return "Spitwads are not free speech.";
    yield return "Spoiler Alert: Unfortunately, my dad doesn't die.";
    yield return "SpongeBob is not a contraceptive.";
    yield return "Substitute teachers are not scabs.";
    yield return "Tar is not a plaything.";
    yield return "Teacher did not pay too much for her condo.";
    yield return "Teacher is not a leper.";
    yield return "Teacher was not dumped—it was mutual.";
    yield return "Teachers diet is working.";
    yield return "Teachers' unions are not ruining this country.";
    yield return "Temptation Island' was not a sleazy piece of crap.";
    yield return "The art teacher is fat, not pregnant.";
    yield return "The boys' room is not a water park.";
    yield return "The cafeteria deep fryer is not a toy.";
    yield return "The capital of Montana is not 'Hannah.'.";
    yield return "The Christmas Pageant does not stink.";
    yield return "The class hamster isn't just sleeping.";
    yield return "The First Amendment does not cover burping.";
    yield return "The Giving Tree is not a chump.";
    yield return "The Good Humor man can only be pushed so far.";
    yield return "The hamster did not have a 'full life'.";
    yield return "The nurse is not dealing.";
    yield return "The Pilgrims were not illegal aliens.";
    yield return "The Pledge of Allegiance does not end with 'Hail Satan'.";
    yield return "The President did it is not an excuse.";
    yield return "The principal's toupée is not a Frisbee.";
    yield return "The Simpsons Halloween Special IX.";
    yield return "The teacher did not get fat during the holidays.";
    yield return "The true location of Springfield is in any state but yours.";
    yield return "The truth is not out there.";
    yield return "The Wall Street Journal is better than ever.";
    yield return "The world may end in 2012, but this show won't.";
    yield return "There are plenty of businesses like show business.";
    yield return "There is no gag in the opening scene.";
    yield return "There is no such month as Rocktober.";
    yield return "There is no such thing as an iPoddy.";
    yield return "There was no Roman god named 'Fartacus'.";
    yield return "There's no proven link between raisins and boogers.";
    yield return "They are laughing at me, not with me.";
    yield return "This counts as gym and art class.";
    yield return "This is not a clue... or is it?";
    yield return "This punishment is not boring and pointless.";
    yield return "This punishment is not medieval.";
    yield return "This school does not need a 'regime change'.";
    yield return "This school is not falling apart.";
    yield return "Tintin did not suck suck.";
    yield return "Today is not Mothra's Day.";
    yield return "Underwear should be worn on the inside.";
    yield return "Vampire is not a career choice.";
    yield return "We are not all naked under our clothes.";
    yield return "We do need no education.";
    yield return "We'll really miss you, Mrs. K.";
    yield return "Wedgies are unhealthy for children and other living things.";
    yield return "When I slept in class, it was not to help Leo DiCaprio.";
    yield return "WWII could not beat up WWI.";
}

#endregion

public static class RyandomNumberGenerator {
    // https://en.wikipedia.org/wiki/Feigenbaum_constants
    public const Int32 Feigenbaum = 46692016;

    public static Int32 Ryandomize(this Int32 lowerBound, Int32 upperBound) {
        Int32 seed = Guid.NewGuid().GetHashCode() % Feigenbaum;
        var rnd = new Random(seed);
        return rnd.Next(lowerBound, upperBound);
    }

    public static Int32 Ryandomize(this Int32 upperBound) => 0.Ryandomize(upperBound);
}

/*
I will not file frivolous lawsuits.
Loose teeth don't need my help.
Pixel art is not real art.
. . .
*/
```