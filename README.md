# Love Game Maker

DISCLAIMER: As of now, this readme is a "filler" readme. Basically it details things as they will be in the project's complete state that may not apply as of now. If you notice an issue with the readme, please submit an "issue" on this file explaining the problem, and I'll fix it right away. Or, if you'd like to take matters into your own hands, fork the repository and make your edits to the readme there. Then submit your modified readme as a pull request. Thanks for reading, and enjoy the project! :)

#What's Love?!?

What's Love? You've never loved someone? You must have a sad life...

All goofiness aside, LÖVE 2D is a fabulous, free, and open-source game engine you can find at http://www.love2d.org
It allows for coding games easily and efficiently using Lua with next to no struggle.

For example, with MonoGame, writing a simple example to print "Hello, world!" to the screen looks something like this:

```C#
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace GameName1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fnt;

        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fnt = Content.Load<SpriteFont>("font");
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(fnt,"Hello, world!", new Vector2(0,0),Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
```

And this is the minimum code with next to no un-needed functions! This doesn't even include adding the spritefont used by this code to actually draw the text to the screen! You need to create one, as without it Monogame will simply error upon attempting to compile.

Now, comparing the above to other languages like C, you'd probably call me an insane man for even attempting to say MonoGame is difficult. Considering how much MonoGame handles for you, I'd be crazy to say it WASN'T easy. It's a marvelous project,  and I definitely have nothing against them.

But what about newbie coders? People simply wanting to learn how to use the engine enough to make a simple game? Having to tell them to type all of the above code may possibly (And more than likely will) scare them off!

This is where LÖVE 2D comes into play. As previously mentioned, LÖVE 2D games are written using Lua. As a programmer who's used many different languages (VB.Net,C,C++,C#,Java,Lua,Batch, and *cough*GML*cough*.), I can easily say that Lua is the easiest programming language I've ever used for many, many reasons. Such as the fact that it's written in very clear english, or that semi-colons are not required at the end of each line. This makes the engine alot easier for new programmers to use, as well as speeding things up drastically for experienced programmers without limiting their potential!

How much easier is it, you ask? Here's the above hello world example except in LÖVE 2D instead of MonoGame:

```lua
function love.draw()
  love.graphics.print("Hello, world!",0,0)
end
```

Yep. That's it. It literally does the exact same thing, and look how much shorter/easier this is!

You're probably thinking this is just an 'excerpt' of the complete code, or something along those lines. After all, 3 lines really isn't alot of code. We didn't even include the actual engine itself! How does the compiler know we want to use LÖVE 2D?

Well, that's just it. LÖVE 2D doesn't use a compiler! Instead, user's code is run using the engine's executable itself, similar to Java. Unlike Java, however, is the fact that code runs surprisingly fast in LÖVE 2D, to the point where there's hardly even a noticeable difference in the speed at which your code runs in LÖVE 2D vs. a compiled game engine!

Best of all, though, is the fact that it's multi-platform and has a great community! While it's currently limited to only Windows, Mac OSX 10.6+, and Linux, the community is very active and has used the source for the engine to port it to various other platforms, such as Android (https://love2d.org/forums/viewtopic.php?f=11&t=79682) and iOS (https://love2d.org/forums/viewtopic.php?f=12&t=76985).

#What's Love Game Maker?

Love Game Maker is a program inspired by Mark Overman's "Game Maker" which allows for easy drag-n-drop coding of games using the LÖVE 2D as a background. It's basically the already-simple LÖVE 2D, but with no actual coding involved!

#But... why? :S

At this point you may be asking youself "If LÖVE 2D is already so easy, why are you making an engine to make it even easier?".

My official answer can be summed up with the following: "Because".

Here we go. This is gonna' be a long one...

See, as easy as LÖVE 2D is, it still involves actual coding. This is something which, unfortunately, many people in today's world are scared of. It's amazing. They'll gladly saw large pieces of wood into whatever shape they want, balance atop the grand canyon's edge, give large speeches in front of easily-offendable audiences, heck, probably even punch wolverines in the face. All without fear! And with a smile, too! But the minute you mention the word "code", they freak out like it's the end of the earth and we're all about to be turned into rabid zombie monkeys who are only capable of communication via shaking their tails in certain patterns.

Because of this, although the vast majority of people would *like* to make games/programs, they're scared to. Because the second you mention there'll be coding involved they'll flee to the nearest avaliable dungeon to hide away for ages. Who knows? They may even turn out to be a master coder who loves making video games more than any thing else, but won't even try it out of fear of messing everything up.

The best example of this is in children. How many kids do you know who would love to make their own video game? Probably a lot! How many of them do you think would actually understand how to code one? Even in a easy-peasy engine such as LÖVE 2D? Probably next-to-none.

I've been coding since I was 8. Do you think I started off with languages such as C++? Heck no! I started off with Game Maker! And even that was complicated to my little 8-year-old mind at the time!

The point I'm trying to make here is that people are scared of the word "code". Programmers have always been portrayed in media as these nerdy geniuses who understand absolutely everything there is to know about the world. Because of this, many people think they can't code because they're "not a programmer", as in "not a genius", and won't even give it a try. What's silly about this is that TRYING IS HOW YOU LEARN!!!

So, why make Love Game Maker? Do you think Love Game Maker will be an advanced coding tool to help people accurately emulate the human brain using nothing but an Intel Celeron? (Tech guys stuck with old laptops will get that joke. ;) ) 

No.

Love Game Maker isn't designed to perform complex tasks. If anything, trying to emulate the human brain in Love Game Maker will only severely hinder your progress. (Yes, I just critised my own program while trying to explain why it's good.)

So what's it designed for, then? Teaching programming newbie's to code?

...Well, actually, no!

Quite simply, Love Game Maker is designed not to teach coding, but to teach the *principle* of coding.

For example, let's take Game Maker. (The program LGM is heavily inspired off of.) Do you think 8-year-old me learned how to make "for loops" to loop through arrays in Game Maker? No! While you certainly CAN do those things in Game Maker, 8-year-old me was scared of coding! Just like practically every one else! I thought it was too difficult! And, when I tried it (using Game Maker's easy-peasy scripting language, "GML"), it kept me from wanting to code as it was too difficult for me, and I was simply un-able to do it.

So what DID Game Maker teach me? The *principle* of coding. Game Maker's drag-n-drop functions didn't teach me complex formulas. Instead, they taught me how code works in a easy to understand way! It didn't teach me how to write C# applications, but rather, it laid the foundation. It didn't throw me out into the fierce wilderness to experience what it's "really like to code". Instead, it did the exact opposite! It made things easy! It held my hand through the already easily-passable field of dasies. Did it teach me coding? No! In fact, it seemingly prevented me from being able to learn! And that's the magic behind it.

I wasn't trapped in a room being forced to listen to a boring seminar on the ways of coding. I wasn't even forced to read an easy-peasy guide on how coding works! Instead I was given tools to keep me from doing any actual coding, and just doing what I wanted in the first place: Making games. So how, then, did Game Maker teach me the principles of coding? It didn't! It laid the foundation for easy drag-n-drop game creation, gave me some handy examples, and said "There ya' go! Enjoy!", leaving me clue-less, but intrigued. Sparking that desire to learn deep within me more than anything else I've ever used before. I was still in the awkward-but-normal stage of wanting to make games, but being scared of coding. But with Game Maker, I wasn't coding! I was just doing what I wanted: making games! This eliminated the fear aspect and simply left me to do the work I wanted to acomplish in the first place.

It did something ingenious and magical. Something school curriculums have been trying, but failing to do for years. It let me learn how to do something without telling me how it worked! It taught me without actually teaching me! It didn't force me to take a lengthy test, but rather, it let me cheat! That is something no other software has been able to accomplish.

Of course, if I needed help, tutorials were avaliable. Lots of them. So many of them, in fact, that I'm still un-able to count them all! But it didn't force me through these tutorials. Rather, it provided them if I needed them and simply said "Figure it out!". This not only inspired me to make games, but learn the software so I'd better understand it and, in turn, be able to make BETTER games. It let me play with my imagination in an easy and secure environment, skipping all the boring tutorials no kid wants to hear. And whenever I came crying back to Game Maker's arms, it was there for me with excellent, but simple documentation for every aspect of the software right at my fingertips! And this isn't even including the previously-mentioned multitude of tutorials made by the community!

And, so, over time, I taught myself Game Maker, which taught me the basic structure of coding. Through-out it I noticed the amount of people using GML (Game Maker's built-in scripting language) to acomplish tasks as opposed to the drag-n-drop functions. I never used it, as I was only confident with my drag-n-drop abilities, not my coding ones. But I always saw the amazing potential of it and wished I understood it.

So, one day, when I was experienced enough with the software and confident enough with my abilities, I decided to try out GML. Slowly but sure-ly I learned it, and without much trouble as the language is designed to let you make mistakes. (Such as not requiring you to declare variables or end your lines with semi-colons.) And before you know it, I wasn't scared of coding!

I then became experienced enough that I noticed Game Maker was actually *limiting* my potential, and made the leap to Visual Basic. Only now, I was condifent in my coding skills and managed to learn a lot of it with little to no trouble.

And, there you have it! I became an official programmer! From then on I was able to easily jump from language-to-language and, well, here I am now. And it's all because of Game Maker!

Game Maker raised me. It turned the kid I was into the programmer I am. It inspired me! It's left me in sheer awe, fascinated by it's amazing "teaching without actual teaching" structure. It's given me ideas. Ideas of a world where children could freely un-leash their imagination in their homes without difficulty. Not just limited to blocks, like in Minecraft, but instead with virtually nothing to hold their little minds back from letting their ideas come to life. Game Maker always made it so easy to learn, but yet taught amazing coding principles that paved the way for the projects I would create later in life. It never felt like a challenge, but instead, an adventure!

It got me thinking, if only I could isolate the magic behind it's "fun learning" structure, and base a program off of that? And that's exactly what I did.

So, why make Love Game Maker? Because. The world already has easy-to-use Game Making software. The world lacks easy-to-use Game making software that really focuses on the learning. I learned how to code using Game Maker. Many did! But, unfortunately, just as many didn't. The approach behind Game Maker wasn't to make a piece of software to teach kids/programming newbies to code. The approach behind Game Maker was to make software to make game creation easier. It just happened to end up as a great tool for teaching code.

Now I'm capitolizing on that.

Love Game Maker isn't made to make coding easier. It's designed to capture the magic behind Game Maker's accidential and mysterious "fun learning" approach, and unleash it. Changing the way people see the word "code", especially children, and teaching it to them, prepping them to do amazing things.

Several projects have already been started to attempt to teach kids to code. Such as the excellent Scratch project by MIT (https://scratch.mit.edu/). But, unfortunately, most of these projects have either had little-to-no effort put into them (Such as Microsoft's "Small Basic" project, or "Kodu Game Lab", both of which they kind of made and then promptly abandoned.), or had lots of effort but were designed to be "too easy" (Such as Scratch), limiting your potential to what that engine can do, and nothing more.

There's a fine line between "too easy" and "too hard". Too easy being incredibly easy to grasp and understand, but extremely limiting when you actually want to do anything with it, discouraging you from completeing your projects, while too hard has unlimited potential, but is just too much for a new user, preventing them from actually learning anything with it. It's a very fine line, one that's all too easy to cross. And, through trial and error, I intend to stand perfectly on it.

And that, fellow readers who actually stuck through this whole thing, is the purpose of Love Game Maker. To be that line. To be the perfect tool for holding your hand and guiding you through the harsh cold, training you, AND letting you unleash your inner potential, all without ever leaving you behind for a single second. It's the perfect combination between your tutor and your favorite clown at the circus. It teaches you important principles while letting you do what you want and all in all just leaves you knowing what you're doing, and having an insane amount of fun while doing it.

#Wow! Sounds great! Is there any way I can help?

Definitely! While I'm confident in my skills to pull something like this off, I can't do it well enough to meet the goals of the project without help from you! That's why this project's on GitHub! So you can contribute your awesome talents to help create the most amazing piece of software that we can!

Here's a quick guide on what YOU can do to help out depending on your skills.

--Can you code in C#?

Awesome! Go ahead and fork the project's source. Then you can clone your fork and make whatever changes you please! After that you just submit merge/pull requests for whatever files you modified/added, and if I see that the changes are for the better (Which I will 80% of the time.), I'll accept your request and your code will be added to the official project! Basically, yeah. It's code. On GitHub. You know the drill. ;)

--Can you draw?

Fancy! You may not realize it, but projects like Love Game Maker actually heavily benefit from nice graphics!
We currently need icons, a logo, some nice example artwork newbies can use without fear of copyright, artwork for the up-coming website, and possibly "promotional" artwork, although this may not be required as screenshots of the software should be enough in most cases. (No, the project won't cost anything. But we still need artwork that makes the program look good/professional enough if we want anyone to actually download it.) If you're good at any of these things and have the time to do it, we'd love your help! Simply draw your artwork the way you normally do and add it to the appropriate folder under the "art" folder of the project.

--Can you Make nice music/sound effects?

Groovy! While the need for music/sound effects for this project is more limited than certain other materials, we still need it! Mainly as resources we can include with the engine that newbie's can use without fear of copyright, as well as audio for project videos ("Promotional", if you will. Although no one's making any money off of this project, so...), and possibly certain sound effects for the application (Although this likely won't really be necessary, as the project isn't really designed to be a very "audible" application.). If you're good at any of these things and have the time to do it, we'd love your help! Simply make your music/sound effects the way you normally do and add it to the appropriate folder under the "audio" folder of the project.

--Are you good at writing?

Superb! You may be thinking to yourself "Oh, you don't need writers. You already typed this thing up by yourself.". Yes. Yes I did. But let me tell you. IT WASN'T FUN/EASY!!! We're in need of writers for lots of things, such as documentation, "promotional" text (The project is non-commercial, as in no one makes any money off it. However, we still need something to encourage new users to download it!), and basically anything like this that requires long, clever, though-out writing (Cuz' my brain can't take it! Geez! It's harder than it looks! xD). If you're good at any of these things and have the time to do so, we'd love your help! We'll post what we need written within "TXTTODO.txt" at the root of the project as well as where to put it, so if you're interested, check it out!

--Are you good at legal gobbly-gook?

OH THANK GOODNESS!!! The project, of course, needs licenses detailing what you can and cannot do with it, much like anything else. The problem is, most of us are focused on making stuff, and while licenses are defintely a major part of, well, pretty much any project, it's something often over-looked as it's extremely complicated for the project creators to sort out by themselves! I, essentially, dread copyright as it means you have to have everything exactly so with no loop holes, or else you're in serious trouble. And it's really hard to make licenses! If you have any legal experience and/or can write detailed licenses with little to no loopholes (While still maintaining a license that's easy-to-read for the average Joe), I'd love your help! PLEASE get in touch with me at radfordhound@gmail.com. I'll explain the current license as well as what kind of license(s) the project (As well as it's assets.) needs in any required detail there. Thanks a bunch! :)

--Are you good at designing things?

Great! We need that! :) One of the most important parts of any piece of software is the user-interface, as most of us know. This often makes or breaks the entire experience and can make the difference between making the user fall in love with our code, or having them curse us for all eternity. It's especially true in this project, however, as one of the most important aspects of it (As mentioned above) is that it's both extremely easy to use for new-comers/kids, but still allows for complex creations without forcing you to drag-n-drop everything with overly-cutesy graphics, all while looking fun and pleasant to the eye, and more like an adventure than a programming IDE. Yeah, I know. That's really hard to do. That's why I need you! If you have any experience with design, specifficaly software design, your help would be greatly appretciated! Simply design a user-interface that matches the requirements listed above (Is easy to use while still allowing for commplexity, etc.), make some way to easily describe/explain it, preferrably with visuals showing how it should look (Such as a powerpoint.), And email it to me at radfordhound@gmail.com. If I like your design, I'll add it to a poll of designs. Whichever design is chosen is the one that shall be used.

Not so good at designing software? That's OK! We still need a website! :D If you have any experience in web design and have a nice, simple, but welcoming design for a site in your head, please e-mail it to me at radfordhound@gmail.com. I'll get back to you as soon as I can.

--Are you good at web development? Such as HTML/Javascript/PHP?

Cool! Obviously, as mentioned several times above, this project needs a website. And not just any website, a website good enough to make people actually want to download the software. It has to be simple and to-the-point without any un-needed baggage holding it down, while still supporting the features needed (Such as a well-built forum and a wiki.) and being pleasing to the eye. If you're good at web development and think you can contribute to any of these things, please get in touch with me at radfordhound@gmail.com! We'll definitely be needing your help! :)

--Can you beta-test software?

Neat! Simply download the latest binary release version of the source within the releases tab, try it out, and submit an "issue" for anything you notice that's wrong with it! Thanks! :)

--Do you have anything else you can contribute?

Are you a good leader? Prove your worth by helping out in any way possible, and I may just make you an administrator over the project/site/forum! Do you have something you're willing to donate for the project? (Such as money, servers, blood, etc. *Just kidding about the blood thing.*) Get in touch with me at radfordhound@gmail.com. We'd very much appreticate that! :) Are you popular? Spread the news! We need as much help as we can get! There's lots of ways you can help out even if you don't meet any of the above critera, so if you have a way of contributing to the project, by all means, go ahead!



Thanks so much to all of you for your epic contributions in advance! It's my hope that, together, we can create something beautiful. :)

...And all of you will be credited, of course. :P  *Duh!*

#What's the license for the project?

The license is detailled in the license.txt file.

#This part of the readme/Project is broken/unfinished!

Thanks for noticing! If it's just been added/modified, that's probably why and I'm likely already aware of it and in the process of fixing it. However, no one knows everything and so there'll likely be thousands of glitches with the project/unfinished things that I'm completely un-aware of!

If you notice something that's "off" and are pretty sure I'm un-aware of it, submit an "issue" about the specific file in question, and I'll respond as quickly as I can. Thanks for your help! :)

#I've got a question that wasn't answered in this readme or would like to contact you personally.

Email me at radfordhound@gmail.com! I'll try to resond ASAP, though please don't expect any record-breaking speed. I don't check my email super often! I should respond to you within a week, so... yeah. :P


Thanks so much for reading this entire thing! This literally took me 2 hours to write! Lol. xD Now you see why I need writers...
