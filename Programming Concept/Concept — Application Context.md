---
tags:
- Concept
date: 2024-12-29
---

# Application Context

## What is

Application context ini suatu container yang dipake tempat naro semua informasi dari App itu sendiri. Informasinya apa? bisa daftar shared resources, config, data, atau functionality kaya maintain state. Karena ini shared dan jadi central hub, maka kuncinya ya global. Kalo global berarti ini Singleton. Karena ini Singleton berarti selalu available di seluruh App lifecycle.

Karena global dan selalu available, semua component di semua bagian App jadi bisa berkomunikasi dengn efisien tanpa passing data secara langsung dari komponen satu ke komponen lain. Passing data dengan App context jadinya semacam naro barang di mangkok. Siapa yang butuh bakal datengin mangkok bukan datengin siapa yang punya barang. Karena sifatnya central hub tadi.



## Pros and Cons

1. <ins>Singleton:</ins>
    Karena dia Singleton dan shared across App, jadinya masing-masing component gak perlu maintain state yang dipake bareng atau resources yang dipake bareng. Cukup pake App Context semua component di App itu bisa langsung pake tanpa harus initialize yang makan resource CPU misalnya atau maintain state bersama yang makan memory misalnya. Semua di satu tempat buat semua jadi CPU dan memory yang dipake bisa jadi lebih hemat.
        
    Tapi masalahnya, karena dia Singleton juga, kalo ada component yang gak berhak buat nge-modify suatu state jadinya bisa modify dan changes-nya itu impacting semua component yang make state tersebut. Jadi mesti hati-hati juga.
2. <ins>Central Hub:</ins>
    Nah karena salah satu fungsinya jadi central hub buat naro data apapun di satu tempat. Kadang developer suka nge-abuse fungsi ini. Issue-nya bisa jadi bloated, terlalu banyak data yang disimpen terus jadi masalah memory yang pada akhirnya bisa aja bikin App-nya lemot atau malah crash.
        
    Mungkin solusi buat issue ini adalah masing-masing component harus maintain stae-nay sendiri kalo mau naro sesuatu di App Context. Kenapa? karena kalo gak di-maintain nanti resources atau data yang udah gak kepake jadi dibiarin dan gak dibersihin jadinya issue memory.



## Example

### Code

```javascript
/// <reference lib="es6" />

///~| Begin: minified Emitter |~///
interface ErrorConstructor{captureStackTrace(error:object,constructor? :Function):void}class EmitterException extends Error{constructor(message? :string){super(message?message:"EmitterException");this.name="EmitterException";if(Error.captureStackTrace){Error.captureStackTrace(this,EmitterException)}}}class EmitterEventArgs{eventName:string;target:unknown;data:Map<string,Record<string,any>> =new Map();constructor(eventName:string,data:Map<string,Record<string,any>>){if(!eventName)throw new EmitterException("Event name must be specified.");this.eventName=eventName;if(!data)throw new EmitterException("Data must be specified.");if(data.size===0)throw new EmitterException("Data must not be empty.");const dataKeys:string[]=Array.from(data.keys());for(const key of dataKeys){const value=data.get(key);this.data.set(key,value!)}}}function isNullOrEmpty(str:string|null|undefined):boolean{return!str||str===null||str.trim()===""}type Action<T>=(param:T)=>void;class Emitter{e:Map<string, Array<Action<EmitterEventArgs>>>=new Map();get count():number{return this.e.size}on(name:string,callback:Action<EmitterEventArgs>):Emitter{if(isNullOrEmpty(name))throw new EmitterException("Name must be specified.");if(!callback)throw new EmitterException("Invalid callback.");if(!this.e.has(name))this.e.set(name,[]);this.e.get(name)!.push(callback);return this};off(name:string):Emitter;off(name:string,callback:Action<EmitterEventArgs> |null):Emitter;off(name:string,callback? :Action<EmitterEventArgs> |null):Emitter{if(isNullOrEmpty(name))throw new EmitterException("Name must be specified.");if(!this.e.has(name))return this;if(!callback||callback===null){this.e.delete(name);return this}const callbacks=this.e.get(name);const liveCallbacks=callbacks!.filter(item=>item!==callback);if(liveCallbacks.length>0)this.e.set(name,liveCallbacks);else this.e.delete(name);return this};once(name:string,callback:Action<EmitterEventArgs>):Emitter{if(isNullOrEmpty(name))throw new EmitterException("Name must be specified.");if(!callback)throw new EmitterException("Invalid callback.");const self=this;let wrapper:Action<EmitterEventArgs>|null=null;wrapper=arg=>{self.off(name,wrapper);callback(arg)};return self.on(name,wrapper)};emit(name:string,arg:EmitterEventArgs):Emitter{if(isNullOrEmpty(name))throw new EmitterException("Name must be specified.");if(!this.e.has(name))return this;const callbacks=this.e.get(name);for(const callback of callbacks!)callback(arg);return this}}
///~| End: minified Emitter |~///

///~| Begin: App Context |~///
var Context: AppContext;

/** ~<<
    NOTE: This is just a dummy code
    to validate this entire code on TS Playground
>>~ */
var Deno: any;

type AppInfo = {
    name: string;
    directory: string;
    isServer: boolean;
    isBrowser: boolean;
}

function getAppInfo(name?: string): AppInfo {
    try {
        const info: AppInfo = {
            name: name ? name : "",
            directory: Deno.cwd(),
            isServer: typeof window === "undefined",
            isBrowser: typeof Deno === "undefined"
        };

        if (!name) {
            const appName = Deno.mainModule.split("/").pop() || "";
            info.name = appName ? appName.split(".")[0] : "";
        }

        return info;
    }
    catch {
        return {
            name: "",
            directory: "",
            isServer: false,
            isBrowser: false
        };
    }
}

class AppContext {
    public appInfo: AppInfo;
    public data: Map<string, Record<string, unknown>>;
    public eventEmitter: Emitter;
    private static instance: AppContext;

    constructor() {
        this.appInfo = getAppInfo();
        this.data = new Map();
        this.eventEmitter = new Emitter();
    }

    public static getInstance(): AppContext {
        if (!this.instance)
            this.instance = new AppContext();

        return this.instance;
    }
}
///~| End: App Context |~///

///~| Begin: App Context usage |~///
globalThis.Context = AppContext.getInstance();
globalThis.Context.appInfo.name = "App Context";
globalThis.Context.data.set("AppData", {
    EmployeeCounterWidgetState: {
        Counts: 523,
        TodayLeaves: 27,
        NewHires: 5,
        ActiveProjects: 48
    },
    EmployeeCalendarWidgetState: {
        ScheduledMeetings: 12,
        Holidays: [
            { date: "2024-12-31", name: "New Year's Eve" },
            { date: "2024-01-01", name: "New Year's Day" }
        ],
        Birthdays: [
            { employeeName: "Alice Johnson", date: "2024-12-28" },
            { employeeName: "Bob Smith", date: "2024-12-29" }
        ],
        LeaveApplications: [
            { employeeName: "John Doe", leaveType: "Sick Leave", duration: "1 Day" },
            { employeeName: "Jane Roe", leaveType: "Annual Leave", duration: "5 Days" }
        ]
    },
    RecruitmentWidgetState: {
        OpenPositions: 12,
        ApplicationsReceived: 432,
        InterviewsScheduled: [
            { candidateName: "Chris Evans", date: "2024-12-30", position: "Software Engineer" },
            { candidateName: "Emily Blunt", date: "2024-12-31", position: "Product Manager" }
        ],
        PositionsFilled: 8
    },
    PayrollWidgetState: {
        TotalPayroll: "$1,200,000",
        BonusesIssued: "$75,000",
        PendingPayments: 3,
        NextPayoutDate: "2024-01-05"
    },
    TrainingWidgetState: {
        OngoingTrainings: [
            { name: "Leadership 101", attendees: 25, completionRate: "80%" },
            { name: "Advanced Coding", attendees: 15, completionRate: "60%" }
        ],
        UpcomingTrainings: [
            { name: "Conflict Resolution", date: "2024-01-10" },
            { name: "Data Analysis", date: "2024-01-15" }
        ],
        CertificatesIssued: 120,
        FeedbackReceived: 85
    }
});
///~| End: App Context usage |~///

console.log({Context: globalThis.Context});
```



### Output

```json
{
  Context: AppContext {
    appInfo: {
      name: "App Context",
      directory: "",
      isServer: false,
      isBrowser: false
    },
    data: Map(1) {
      "AppData" => {
        EmployeeCounterWidgetState: {
          Counts: 523,
          TodayLeaves: 27,
          NewHires: 5,
          ActiveProjects: 48
        },
        EmployeeCalendarWidgetState: {
          ScheduledMeetings: 12,
          Holidays: [Array],
          Birthdays: [Array],
          LeaveApplications: [Array]
        },
        RecruitmentWidgetState: {
          OpenPositions: 12,
          ApplicationsReceived: 432,
          InterviewsScheduled: [Array],
          PositionsFilled: 8
        },
        PayrollWidgetState: {
          TotalPayroll: "$1,200,000",
          BonusesIssued: "$75,000",
          PendingPayments: 3,
          NextPayoutDate: "2024-01-05"
        },
        TrainingWidgetState: {
          OngoingTrainings: [Array],
          UpcomingTrainings: [Array],
          CertificatesIssued: 120,
          FeedbackReceived: 85
        }
      }
    },
    eventEmitter: Emitter { e: Map(0) {} }
  }
}
```