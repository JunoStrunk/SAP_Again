// Copyright Juno Strunk

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/HUD.h"
#include "SAPHUD.generated.h"

class USAPBaseWidget;

/**
 * 
 */
UCLASS()
class SAP_FRONTEND_API ASAPHUD : public AHUD
{
	GENERATED_BODY()

public:
    // Public functions

    /// @brief Add a widget to the viewport and track it. This should only be used for "frames" like panels and grouped UI. Not individiual buttons or text
    /// @param widget - SAPBaseWidget to add to viewport.
    UFUNCTION(BlueprintCallable)
    void AddWidget(USAPBaseWidget* const widget);


private:
    // Private Variables
    UPROPERTY()
    TArray<USAPBaseWidget*> WidgetStack;


};
