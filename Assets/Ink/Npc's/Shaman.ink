


=== Shaman === 
{CollectObjectsState:
    -"Finished": -> finished
    -else: -> default
}


= finished
The ritual can start now
->END

= default
Do you want to start the quest?

* [Yes]
    ~FinishDay(CollectItemsQuestId)
    i'll do what i can with these
    no promises
    ->END
* [No]
    then go find the items
->END
