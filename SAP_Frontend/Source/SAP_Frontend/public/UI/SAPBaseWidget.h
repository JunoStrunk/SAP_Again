// Copyright Juno Strunk

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "SAPBaseWidget.generated.h"

UENUM(BlueprintType)
enum class EWidgetType : uint8
{
    BASE UMETA(DisplayName = "BASE"),
    ADDITIVE UMETA(DisplayName = "ADDITIVE")
};

/**
 * 
 */
UCLASS(Abstract)
class SAP_FRONTEND_API USAPBaseWidget : public UUserWidget
{
	GENERATED_BODY()

public:
    UFUNCTION(BlueprintCallable)
    void ShowWidget();

    UFUNCTION(BlueprintCallable)
    void TransitionToWidget(USAPBaseWidget* const widget);

public:
    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Widget Attributes")
    EWidgetType Type;

};
