import { Bank, Level, OptionOnLeave, Position, Priority, ProjectType, Status, StatusTask } from "../enums/Enum";

export interface ApiResponse {
    statusCode: number,
    message: string,
    data: any,
}
export interface LoginResponse {
    id: string;
    fullName: string;
    sex: boolean;
    email: string,
    phone: string,
    doB: Date,
    level: Level,
    position: Position,
    departmentId: string,
    startingDate: Date,
    bank: Bank | null,
    bankAccount: string,
    taxCode: string,
    insuranceStatus: string,
    identify: string,
    placeOfOrigin: string,
    placeOfResidence: string,
    dateOfIssue: string,
    issuedBy: string,
    userCode: string
}

export interface DepartmentResponse {
    id: string,
    name: string,
    color: string,
    icon: string
}

export interface OnLeaveResponse {
    id: string,
    employeeId: string,
    dateLeave: Date,
    option: OptionOnLeave,
    reason: string,
    status: Status
}

export interface TimeWorkingResponse {
    id: string,
    employeeId: string,
    morningStartTime: Date,
    morningEndTime: Date,
    afternoonStartTime: Date,
    afternoonEndTime: Date,
    applyDate: Date,
    status: Status
}

export interface ProjectResponse {
    id: string,
    projectName: string,
    description: string,
    projectType: ProjectType,
    projectCode: string,
    createDate: Date,
    deadlineDate: Date,
    completeDate: Date | null,
    priorityCode: Priority,
    statusCode: StatusTask,
    pm: string
}

export interface TimeKeepingResponse {
    id: string | null,
    employeeId: string,
    date: Date,
    checkin: Date,
    photoCheckin: string,
    checkout: Date,
    photoCheckout: string,
    complain: string,
    punish: boolean,
}