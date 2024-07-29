"use client";

// import { useQuery } from "@tanstack/react-query";

import { Button, Card } from "flowbite-react";
// import { useDispatch } from "react-redux";

const fetchAccounts = async () => {
    const response = await fetch('https://localhost:7292/api/accounts');
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return response.json();
};

const data: Array<{ id: string; accountName: string; userEmail: string; rootDirectoryId: string }> = [
    { id: "asdfsadf-asdfsadf23-2323-fadsf", accountName: "Prabin", userEmail: "Hello@world", rootDirectoryId: "234234234-23423424-23424324" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", accountName: "Prabin", userEmail: "Hello@world", rootDirectoryId: "234234234-23423424-23424324" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", accountName: "Prabin", userEmail: "Hello@world", rootDirectoryId: "234234234-23423424-23424324" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", accountName: "Prabin", userEmail: "Hello@world", rootDirectoryId: "234234234-23423424-23424324" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", accountName: "Prabin", userEmail: "Hello@world", rootDirectoryId: "234234234-23423424-23424324" },
];

export function AccountList() {
    // const dispatch = useDispatch();
    // const { data, error, isLoading } = useQuery({
    //     queryKey: ['accounts'],
    //     queryFn: fetchAccounts,
    // });

    // if (isLoading) return <p className="text-gray-900 dark:text-white">Loading...</p>;
    // if (error instanceof Error) return <p className="text-gray-900 dark:text-white">Error: {error.message}</p>;

    return (
        <div className="mx-auto w-3/4 max-w-2xl flex flex-col items-center gap-4">
            <div className="flex justify-between my-4 w-full">
                <h1 className="text-2xl font-bold self-start text-gray-900 dark:text-white block">
                    Available Accounts
                </h1>
                <div>
                    <Button>Create Account</Button>
                </div>
            </div>
            {data?.map((account: { id: string; accountName: string; userEmail: string; rootDirectoryId: string }) => (
                <Card href={`/accounts/${account.rootDirectoryId}`} className="w-full">
                    <div className="flex flex-col gap-2">
                        <p className="text-xl font-bold text-gray-900 dark:text-white flex justify-between items-center">
                            {account.accountName}
                            <span>
                                <svg className="w-[26px] h-[26px] text-red-700" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.8" d="M5 7h14m-9 3v8m4-8v8M10 3h4a1 1 0 0 1 1 1v3H9V4a1 1 0 0 1 1-1ZM6 7h12v13a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7Z" />
                                </svg>
                            </span>
                        </p>
                        <p className="font-normal text-gray-700 dark:text-gray-400">
                            {account.userEmail}
                        </p>
                        <p className="font-normal text-gray-700 dark:text-gray-400">
                            {account.id}
                        </p>
                    </div>
                </Card>
            ))}
        </div>
    );
}
