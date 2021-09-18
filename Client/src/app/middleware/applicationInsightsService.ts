import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { ApplicationInsights, IExceptionTelemetry, IPageViewTelemetry, ITelemetryPlugin } from '@microsoft/applicationinsights-web';
import { AngularPlugin } from '@microsoft/applicationinsights-angularplugin-js';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AppInsightsService {

  private appInsights: ApplicationInsights;

  constructor(private readonly router: Router) {
    const angPlugin = new AngularPlugin() as unknown as ITelemetryPlugin;
    this.appInsights = new ApplicationInsights({
      config: {
        connectionString: environment.applicationInsights.connectionString,
        extensions: [angPlugin],
        extensionConfig: {
          [angPlugin.identifier]: { router: this.router }
        }
      }
    });

    this.appInsights.loadAppInsights();
    this.appInsights.startTrackPage();
    this.appInsights.startTrackEvent();
    //this.appInsights.addTelemetryInitializer(() => false);
  }

  trackError(exTelemetry: IExceptionTelemetry) {
    this.appInsights.trackException(exTelemetry);
  }

  trackPage(pageTelemetry: IPageViewTelemetry) {
    this.appInsights.trackPageView(pageTelemetry);
  }
}
