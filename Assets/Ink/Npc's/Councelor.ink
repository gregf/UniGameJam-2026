EXTERNAL StartDay(string questId)
EXTERNAL Reminder(string questId)
EXTERNAL FinishDay(string questId)
EXTERNAL WhatWords(string questId)

VAR CollectObjectsState = "NOT_ENOUGH_ITEMS"

=== Councelor ===
{ CollectObjectsState:
    -"NOT_ENOUGH_ITEMS": -> Councelor0
    -"ENOUGH_ITEMS": -> Councelor1
    -else: -> END

}

->END


= Councelor0
Dat noo enough Ντραμλα
Πανε find mo

->END

= Councelor1
Dat ειναι αρκετα Ντραμλα
Go make da bomcera

->END