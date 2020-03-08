import { Injectable } from "@angular/core";
import { makeText, Toast } from "nativescript-toast";
import { Color } from "tns-core-modules/color";
import { isIOS } from "tns-core-modules/platform";
import { Font } from "tns-core-modules/ui/styling/font";
import { Config } from "~/shared/config";

declare const ToastView, UIFont;

@Injectable()
export class ToastService {

  private previousToast: Toast = null;
  private androidTypeface: any;

  constructor() {
    if (isIOS) {
      // for properties see https://github.com/devxoul/Toaster
      ToastView.appearance().bottomOffsetPortrait = 40;
      ToastView.appearance().bottomOffsetLandscape = 40;
      ToastView.appearance().backgroundColor = new Color(240, 70, 70, 70).ios;
      ToastView.appearance().font = UIFont.fontWithNameSize("Source Sans Pro", Config.isTablet ? 20 : 16);
    } else {
      let f = new Font("SourceSansPro-Regular", (Config.isTablet ? 17 : 14), "normal", "normal");
      this.androidTypeface = f.getAndroidTypeface();
    }
  }

  show(message: string, long?: boolean) {
    if (this.previousToast) {
      this.previousToast.cancel();
      this.previousToast = null;
    }

    let t = makeText(message, long ? "long" : undefined);

    if (!isIOS) {
      (<any>t).getView().getChildAt(0).setTypeface(this.androidTypeface);
    }

    t.show();
    this.previousToast = t;
  }
}
