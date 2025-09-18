// Copyright Juno Strunk


#include "SAPHUD.h"
#include "UI/SAPBaseWidget.h"

void ASAPHUD::AddWidget(USAPBaseWidget* const widget)
{
    if (widget == nullptr)
    {
        UE_LOG(LogTemp, Error, TEXT("Add widget called with nullptr"));
        return;
    }

    // If widget is a base widget we want to remove every other widget currently on screen
    if (widget->Type == EWidgetType::BASE)
    {
        // Loop through widgets and remove them
        while (WidgetStack.Num() > 0)
        {
            WidgetStack.Top()->RemoveFromParent();
            WidgetStack.Pop();
        }
    }

    widget->AddToViewport(WidgetStack.Num());
    WidgetStack.Push(widget);
}
