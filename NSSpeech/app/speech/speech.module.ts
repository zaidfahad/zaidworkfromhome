import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { SpeechRoutingModule } from "./speech-routing.module";
import { SpeechComponent } from "./speech.component";
import { TNSFontIconModule } from "nativescript-ngx-fonticon";
import { DebounceModule } from "~/modules/debounce/debounce.module";

@NgModule({
  imports: [
    NativeScriptCommonModule,
    SpeechRoutingModule,
    TNSFontIconModule,
    DebounceModule,
  ],
  declarations: [
    SpeechComponent
  ],
  schemas: [
    NO_ERRORS_SCHEMA
  ]
})
export class SpeechModule {
}
