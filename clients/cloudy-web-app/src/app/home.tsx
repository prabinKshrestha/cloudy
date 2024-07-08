import { Card } from "flowbite-react";

export default function Home() {
    return (
        <div className="h-full flex-col flex items-center justify-center">
            <div className="text-5xl text-gray-900 dark:text-white font-bold mb-20">Welcome to Cloudy</div>
            <div className='flex justify-center items-center gap-8'>
                <Card href='/accounts' className="max-w-sm w-96">
                    <h5 className="text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                        View Accounts
                    </h5>
                    <p className="font-normal text-gray-700 dark:text-gray-400">
                        View all accounts you have created.
                    </p>
                </Card>
                <Card className="max-w-sm  w-96">
                    <h5 className="text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                        New Account ?
                    </h5>
                    <p className="font-normal text-gray-700 dark:text-gray-400">
                        Create new account and start from scratch.
                    </p>
                </Card>
            </div>
        </div>
    );
}