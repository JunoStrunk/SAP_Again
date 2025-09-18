// Copyright Juno Strunk


#include "UI/SAPBaseWidget.h"
#include "SAPHUD.h"

#include <Kismet/GameplayStatics.h>

void USAPBaseWidget::ShowWidget()
{
    TransitionToWidget(this);
}

void USAPBaseWidget::TransitionToWidget(USAPBaseWidget* const widget)
{
    APlayerController* playerController = UGameplayStatics::GetPlayerController(GetWorld(), 0);

    check(playerController != nullptr);

    ASAPHUD* hud = Cast<ASAPHUD>(playerController->GetHUD());

    check(hud != nullptr);

    hud->AddWidget(widget);
}
