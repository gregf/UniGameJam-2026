
=== Councelor ===
{ CollectObjectsState:
    -"NOT_ENOUGH_ITEMS": -> Councelor1
    -"ENOUGH_ITEMS": -> CouncelorNII
    -else: -> END

}

->END

= CouncelorNII
go find more
->END

= Councelor1
Good day!
I am very much looking forward to the Mushroom Ceremony. 
I hope you managed to collect the Three-legged bowl and the Yellow Mask from the ritual storage rooms. 
Youngsters from the tribe forgot their proper names already. 
But I trust you remember them correctly
* [Cow Skull and a Pitcher] -> Councelor1f
* [Corn and Hibiscus] -> Councelor1f
* [Three-legged bowl and Yellow Mask] -> Councelor1t
* [Goat shit and prayers] -> Councelor1f

= Councelor1f
 I haven’t even heard this much bullshit from my bull rider academy. 
 Do you at least know what a Red Robe is? 
 The leaders (even the ones not blessed by the Gods of Wisdom) need to wear it to represent the blood we shed and the rising sun that brings a new day.
->Councelor2
= Councelor1t
Good to know that our leader is familiar with the ancient tongue. 
You should go grab the Red Robe now. 
It represents the blood we shed and the rising sun that brings a new day. 
It is important that the leader of the ceremony wears it. 
I hope you know what you are looking for?
->Councelor2

= Councelor2
* [Red Robe] ->Councelor2t
* [Blue Robe] ->Councelor2f
* [Red Pot] ->Councelor2f
* [Green Underwear] ->Councelor2f

= Councelor2t
I’m impressed. You know your role well. 
The last thing you need to bring to the ceremony is Honey and Mushrooms, as it is important to add a sweeter taste to them for a smoother immersion into the trance. 
This is the most famous element of the ceremony so you have to get it right.
->Councelor3

= Councelor2f
Did you seduce all people in the tribe to select you as a new leader? 
They definitely didn’t choose you for your wits. 
You probably know better moves than they taught me in my prostitute academy. 
I hope you at least know that you need to serve Honey and Mushrooms at the ceremony? 
It is important to add a sweeter taste to them for a smoother immersion into the trance.
->Councelor3


= Councelor3
Yes, I will bring
* [Beans and Hibiscus] ->Councelorf
* [Knives and Purslane] ->Councelorf
* [Your mum and Condoms] ->Councelorf
* [Honey and Mushrooms] ->Councelorf


=== Councelorf ===
    ~StartDay(CollectItemsQuestId)
->END

















