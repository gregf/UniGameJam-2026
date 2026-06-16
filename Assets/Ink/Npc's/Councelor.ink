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
keep finding items

->END

= Councelor1
enough items

->END